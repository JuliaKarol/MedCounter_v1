
namespace MedCounter_logic_mockup2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1 = new RJCodeAdvance.RJControls.RJButton();
            this.Button2 = new RJCodeAdvance.RJControls.RJButton();
            this.CountToAmount = new System.Windows.Forms.RichTextBox();
            this.Counted = new System.Windows.Forms.RichTextBox();
            this.Clear = new RJCodeAdvance.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SetAmountWarning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SetAmount = new RJCodeAdvance.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Button1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Button1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Button1.BorderRadius = 0;
            this.Button1.BorderSize = 0;
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(69, 104);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(128, 46);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Button1";
            this.Button1.TextColor = System.Drawing.Color.White;
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Button2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Button2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Button2.BorderRadius = 0;
            this.Button2.BorderSize = 0;
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.ForeColor = System.Drawing.Color.White;
            this.Button2.Location = new System.Drawing.Point(256, 99);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(140, 56);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Button2";
            this.Button2.TextColor = System.Drawing.Color.White;
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CountToAmount
            // 
            this.CountToAmount.Location = new System.Drawing.Point(562, 76);
            this.CountToAmount.Name = "CountToAmount";
            this.CountToAmount.Size = new System.Drawing.Size(114, 28);
            this.CountToAmount.TabIndex = 2;
            this.CountToAmount.Text = "";
            this.CountToAmount.TextChanged += new System.EventHandler(this.CountToAmount_TextChanged);
            // 
            // Counted
            // 
            this.Counted.Location = new System.Drawing.Point(571, 155);
            this.Counted.Name = "Counted";
            this.Counted.ReadOnly = true;
            this.Counted.Size = new System.Drawing.Size(104, 28);
            this.Counted.TabIndex = 3;
            this.Counted.Text = "";
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Clear.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Clear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Clear.BorderRadius = 0;
            this.Clear.BorderSize = 0;
            this.Clear.FlatAppearance.BorderSize = 0;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.ForeColor = System.Drawing.Color.White;
            this.Clear.Location = new System.Drawing.Point(562, 218);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(113, 37);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Clear";
            this.Clear.TextColor = System.Drawing.Color.White;
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // SetAmountWarning
            // 
            this.SetAmountWarning.AutoSize = true;
            this.SetAmountWarning.Location = new System.Drawing.Point(568, 107);
            this.SetAmountWarning.Name = "SetAmountWarning";
            this.SetAmountWarning.Size = new System.Drawing.Size(103, 13);
            this.SetAmountWarning.TabIndex = 7;
            this.SetAmountWarning.Text = "Set amount to count";
            this.SetAmountWarning.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Counted";
            // 
            // SetAmount
            // 
            this.SetAmount.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.SetAmount.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.SetAmount.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SetAmount.BorderRadius = 0;
            this.SetAmount.BorderSize = 0;
            this.SetAmount.FlatAppearance.BorderSize = 0;
            this.SetAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetAmount.ForeColor = System.Drawing.Color.White;
            this.SetAmount.Location = new System.Drawing.Point(710, 47);
            this.SetAmount.Name = "SetAmount";
            this.SetAmount.Size = new System.Drawing.Size(69, 40);
            this.SetAmount.TabIndex = 9;
            this.SetAmount.Text = "Set Amount";
            this.SetAmount.TextColor = System.Drawing.Color.White;
            this.SetAmount.UseVisualStyleBackColor = false;
            this.SetAmount.Click += new System.EventHandler(this.SetAmount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SetAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SetAmountWarning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Counted);
            this.Controls.Add(this.CountToAmount);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJCodeAdvance.RJControls.RJButton Button1;
        private RJCodeAdvance.RJControls.RJButton Button2;
        private System.Windows.Forms.RichTextBox CountToAmount;
        private System.Windows.Forms.RichTextBox Counted;
        private RJCodeAdvance.RJControls.RJButton Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SetAmountWarning;
        private System.Windows.Forms.Label label4;
        private RJCodeAdvance.RJControls.RJButton SetAmount;
    }
}

