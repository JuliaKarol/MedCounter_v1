using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJCodeAdvance.RJControls;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MedCounter_logic_mockup2;
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

namespace ClassLibrary1
{
    class GetValue
    {
        public static object GetPropValue(object src, string propName)
 {
     return src.GetType().GetProperty(propName).GetValue(src, null);
 }
    }
    class ButtonPressFunction
    {  
        Dictionary<RJButton, int> buttonClickCounter;

        int counter
        {
            get
            { return buttonClickCounter.Sum(x => x.Value); }
        }

        public double amountSetByUser
        {
            get { return amountSetByUser; }
            set
            {
                try
                {
                    amountSetByUser = Double.Parse(GetValue.GetPropValue(CountToAmount.Text));//wziete z textu, jak przekazac
                    if (value == 0) { throw new FormatException(); };//into the validator you go//set state exception
                }
                catch (FormatException)
                {
                    var exception = new ExceptionHandler();
                    exception.Handler();
                }
            }
        }
        double countedByUser;
        public bool CheckMath()//somebssnslogic
        {
            if (amountSetByUser == 0)
            {
                throw new FormatException();//set exceptionstate
            }
            if (counter == amountSetByUser)
            {
                var disable = new ButtonAcessiblility();
                disable.DisableKeys();
                Form1.Clear.Enabled = true;
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
                    button.Text = buttonClickCounter[button].ToString();//state changetext, else excsgate
                }
            }
            catch (FormatException)
            {
                var exception = new ExceptionHandler();
                exception.Handler();
            }
        }
        //checkMath
        //do stuff
    }
    public class ExceptionHandler
    {
        public void Handler()
        {
            SetAmountWarning.Visible = true;
            SetAmount.Enabled = true;
            CountToAmount.Enabled = true;
            
        }

    }

    public class ButtonAcessiblility
    {
        
        public void SetAmount()
        {
            CountToAmount.Enabled = false;
            SetAmountWarning.Visible = false;
            EnableKeys();
        }
        public void DisableKeys()
        {
            foreach (var b in Controls.OfType<Button>())
            {
                b.Enabled = false;
            }
        }
        public void EnableKeys()
        {
            foreach (var b in Controls.OfType<Button>())
            {
                b.Enabled = true;
            }
        }
        public void Clear()
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
            //end
            //nope
            //clear
        }
    }
}
