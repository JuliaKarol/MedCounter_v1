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
using ClassLibrary1;



namespace MedCounter_logic_mockup2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ButtonPressFunction amount = new ButtonPressFunction();
            CountToAmount.Text = amount.amountSetByUser.ToString();
            var disable = new ButtonAcessiblility();
            disable.DisableKeys();
            SetAmount.Enabled = true;
            string text = Counted.Text;
            foreach (var b in Controls.OfType<Button>())
            {
                b.Enabled = false;
            }
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            var button2 = new ButtonPressFunction();
            button2.CheckMath();
            button2.DoStuff(Button2);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var button1 = new ButtonPressFunction();
            button1.CheckMath();
            button1.DoStuff(Button1);

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
       
        private void CountToAmount_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        
        private void Clear_Click(object sender, EventArgs e)
        {
            
        }
        private void SetAmount_Click(object sender, EventArgs e)
        {
           
        }  
    }
}
