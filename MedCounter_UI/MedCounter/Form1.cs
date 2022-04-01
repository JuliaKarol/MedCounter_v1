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
    public partial class Form1 : Form
    {

        private int borderSize = 2;
        private Size formSize;
        Dictionary<RJButton, int> buttonClickCounter;
        int counter
        {
            get
            { return buttonClickCounter.Sum(x => x.Value); }
        }
        double amountSetByUser;
        double countedByUser;
        public Form1()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(50, 133, 66);
            CollapseMenu();
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
        #region UI
        ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
        //UI <Doc>https://rjcodeadvance.com/final-modern-ui-aero-snap-window-resizing-sliding-menu-c-winforms/</Doc>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; 
            const int SC_RESTORE = 0x09;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;
            
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void bttnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bttnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void bttnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bttnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: 
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: 
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200)
            {
                panelMenu.Width = 100;
                iconPictureBox1.Visible = false;
                bttnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { 
                panelMenu.Width = 230;
                iconPictureBox1.Visible = true;
                bttnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);    
                }
            }
        }
        #endregion

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
                    button.Text = buttonClickCounter[button].ToString();
                }
            }
            catch (FormatException)
            {
                ExceptionsHandler();
            }
        }
       
            public string Display(RJButton button) {
            string a = null;  
            int b = buttonClickCounter[button];
            string c= (b/ counter).ToString("0.00%");
            string d = $"{a} + \n + {c}";
            return d;}
        
        
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
        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

