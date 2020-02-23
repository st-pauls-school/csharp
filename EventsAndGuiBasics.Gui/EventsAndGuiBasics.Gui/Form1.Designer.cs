namespace EventsAndGuiBasics.Gui
{
    partial class frmMain
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
            this.btnStartTicker = new System.Windows.Forms.Button();
            this.btnStopTicker = new System.Windows.Forms.Button();
            this.lblTicker = new System.Windows.Forms.Label();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnStartTicker
            // 
            this.btnStartTicker.Location = new System.Drawing.Point(37, 142);
            this.btnStartTicker.Name = "btnStartTicker";
            this.btnStartTicker.Size = new System.Drawing.Size(75, 23);
            this.btnStartTicker.TabIndex = 0;
            this.btnStartTicker.Text = "StartTicker";
            this.btnStartTicker.UseVisualStyleBackColor = true;
            this.btnStartTicker.Click += new System.EventHandler(this.btnStartTicker_Click);
            // 
            // btnStopTicker
            // 
            this.btnStopTicker.Enabled = false;
            this.btnStopTicker.Location = new System.Drawing.Point(118, 142);
            this.btnStopTicker.Name = "btnStopTicker";
            this.btnStopTicker.Size = new System.Drawing.Size(75, 23);
            this.btnStopTicker.TabIndex = 1;
            this.btnStopTicker.Text = "Stop Ticker";
            this.btnStopTicker.UseVisualStyleBackColor = true;
            this.btnStopTicker.Click += new System.EventHandler(this.btnStopTicker_Click);
            // 
            // lblTicker
            // 
            this.lblTicker.AutoSize = true;
            this.lblTicker.Location = new System.Drawing.Point(34, 168);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(47, 13);
            this.lblTicker.TabIndex = 2;
            this.lblTicker.Text = "<empty>";
            // 
            // cbList
            // 
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(445, 114);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(121, 21);
            this.cbList.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbList);
            this.Controls.Add(this.lblTicker);
            this.Controls.Add(this.btnStopTicker);
            this.Controls.Add(this.btnStartTicker);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartTicker;
        private System.Windows.Forms.Button btnStopTicker;
        private System.Windows.Forms.Label lblTicker;
        private System.Windows.Forms.ComboBox cbList;
    }
}

