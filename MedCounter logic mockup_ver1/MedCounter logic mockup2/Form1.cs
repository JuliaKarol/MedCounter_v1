using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJCodeAdvance.RJControls;

namespace MedCounter_logic_mockup2
{
    public partial class Form1 : Form
    {
        Dictionary<RJButton, int> buttonClickCounter;
        int counter
        {
            get { return buttonClickCounter.Sum(x => x.Value); }
        }
        double amountSetByUser;
        double countedByUser;
        public Form1()
        {
            InitializeComponent();
            CountToAmount.Text = amountSetByUser.ToString();
            DisableKeys();
            SetAmount.Enabled = true;
            buttonClickCounter = new Dictionary<RJButton, int>();
            foreach(var c in this.Controls)
            {
                if (c is RJButton)
                    buttonClickCounter.Add(c as RJButton, 0);
            }
            
        }
        private bool CheckMath()
        {
            if (amountSetByUser == 0)
            {
               throw new FormatException();//into the validator you go
            }
            else if (counter == amountSetByUser)//counter into prop you go?
            {
                DisableKeys();
                Clear.Enabled = true;
                Counted.Text = amountSetByUser.ToString();
                return false;
            }
            else
            {
                countedByUser++;
                Counted.Text = countedByUser.ToString();
                return true;
            }
        }
        public void DoStuff(RJButton button)
        {
            try
            {
            if (CheckMath() == true)
            {
                ++buttonClickCounter[button];
                button.Text = buttonClickCounter[button].ToString();
                }
                else
                {
                    button.Text = Display(button);
                }
            }
            catch (FormatException)
            {
                ExceptionsHandler();
            }
        }
        public string Display(RJButton button)
        {
            string a = buttonClickCounter[button].ToString();
            int b = buttonClickCounter[button];
            string c = (b/counter).ToString();
            string d = $"{a}\n{c}";
            return d;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DoStuff(Button2);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DoStuff(Button1);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad7)//inaczej
            {
                Button1.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                Button2.PerformClick();
            }
        }
        private void ExceptionsHandler()
        {
            SetAmountWarning.Visible = true;
            DisableKeys();
            SetAmount.Enabled = true;
            CountToAmount.Enabled = true;

        }
        private void CountToAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                amountSetByUser = Double.Parse(CountToAmount.Text);//into the validator you go
            }
            catch (FormatException)
            {
                ExceptionsHandler();
            }
        }
        private void DisableKeys()
        {
            foreach (var b in Controls.OfType<Button>())
            {
                b.Enabled = false;
            }
        }
        private void EnableKeys()
        {
            foreach (var b in Controls.OfType<Button>())
            {
                b.Enabled = true;
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
        private void SetAmount_Click(object sender, EventArgs e)
        {
            CountToAmount.Enabled = false;
            SetAmountWarning.Visible = false;
            EnableKeys();
        }  
    }
}
