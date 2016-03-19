namespace TabDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageEX1 = new ControlEX.TabPageEX();
            this.tabPageEX2 = new ControlEX.TabPageEX();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPageEX3 = new ControlEX.TabPageEX();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPageEX4 = new ControlEX.TabPageEX();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabPageEX1
            // 
            this.tabPageEX1.Location = new System.Drawing.Point(4, 24);
            this.tabPageEX1.Name = "tabPageEX1";
            this.tabPageEX1.Size = new System.Drawing.Size(577, 72);
            this.tabPageEX1.TabIndex = 0;
            this.tabPageEX1.Text = "TabPageEX";
            this.tabPageEX1.ToolTipText = "TabPageEX";
            this.tabPageEX1.Visible = false;
            // 
            // tabPageEX2
            // 
            this.tabPageEX2.Location = new System.Drawing.Point(4, 24);
            this.tabPageEX2.Name = "tabPageEX2";
            this.tabPageEX2.Size = new System.Drawing.Size(577, 72);
            this.tabPageEX2.TabIndex = 1;
            this.tabPageEX2.Text = "New";
            this.tabPageEX2.ToolTipText = "New";
            this.tabPageEX2.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 72);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "newTabEX0";
            this.tabPage1.ToolTipText = "newTabEX0";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPageEX3
            // 
            this.tabPageEX3.Location = new System.Drawing.Point(4, 24);
            this.tabPageEX3.Name = "tabPageEX3";
            this.tabPageEX3.Size = new System.Drawing.Size(577, 72);
            this.tabPageEX3.TabIndex = 3;
            this.tabPageEX3.Text = "New";
            this.tabPageEX3.ToolTipText = "New";
            this.tabPageEX3.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 72);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "newTabEX1";
            this.tabPage2.ToolTipText = "newTabEX1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPageEX4
            // 
            this.tabPageEX4.Location = new System.Drawing.Point(4, 24);
            this.tabPageEX4.Name = "tabPageEX4";
            this.tabPageEX4.Size = new System.Drawing.Size(577, 72);
            this.tabPageEX4.TabIndex = 5;
            this.tabPageEX4.Text = "New";
            this.tabPageEX4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 495);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlEX.TabPageEX tabPageEX1;
        private ControlEX.TabPageEX tabPageEX2;
        private System.Windows.Forms.TabPage tabPage1;
        private ControlEX.TabPageEX tabPageEX3;
        private System.Windows.Forms.TabPage tabPage2;
        private ControlEX.TabPageEX tabPageEX4;
        private System.Windows.Forms.Button button1;
    }
}