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
using System.Runtime.InteropServices;

namespace MedCounter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CountToAmount.Text = amountSetByUser.ToString();
            DisableKeys();
            SetAmount.Enabled = true;
            buttonClickCounter = new Dictionary<RJButton, int>();
            foreach (var c in this.Controls)
            {
                if (c is RJButton)
                    buttonClickCounter.Add(c as RJButton, 0);
            }
        }
        Dictionary<RJButton, int> buttonClickCounter;
        int counter
        {
            get
            { return buttonClickCounter.Sum(x => x.Value); }
        }
        double amountSetByUser;
        double countedByUser;
       
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
        private bool CheckMath()
        {
            if (amountSetByUser == 0)
            {
                throw new FormatException();
            }
            if (counter == amountSetByUser)
            {
                DisableKeys();
                Clear.Enabled = true;
                AllClicksByUser.Text = amountSetByUser.ToString();
                return false;
            }
            else
            {
                countedByUser++;
                AllClicksByUser.Text = countedByUser.ToString();
                return true;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad7)
            {
                Button1.PerformClick();//lambda
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                Button2.PerformClick();//lambda
            }
        }
        public void DoStuff(RJButton button)
        {
            try
            {
                if (CheckMath() == true)
                {
                    ++buttonClickCounter[button];
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
            string c = (b / counter).ToString("0.00%");
            string d = $"{a} + \n + {c}";
            return d;
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
                amountSetByUser = Double.Parse(CountToAmount.Text);
            }
            catch (FormatException)
            {
                ExceptionsHandler();
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
        private void Button2_Click(object sender, EventArgs e)
        {
            DoStuff(Button2);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DoStuff(Button1);
        }
    }
}

