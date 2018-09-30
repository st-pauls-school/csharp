namespace PumpViewer
{
    partial class PumpForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPricePerLitre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPumpState = new System.Windows.Forms.Label();
            this.lblPumpStateDescription = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLift = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCost);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblPricePerLitre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblPumpState);
            this.panel1.Controls.Add(this.lblPumpStateDescription);
            this.panel1.Controls.Add(this.btnReplace);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnLift);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 536);
            this.panel1.TabIndex = 0;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(236, 160);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(0, 13);
            this.lblCost.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(236, 115);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(0, 13);
            this.lblQuantity.TabIndex = 10;
            // 
            // lblPricePerLitre
            // 
            this.lblPricePerLitre.AutoSize = true;
            this.lblPricePerLitre.Location = new System.Drawing.Point(236, 70);
            this.lblPricePerLitre.Name = "lblPricePerLitre";
            this.lblPricePerLitre.Size = new System.Drawing.Size(35, 13);
            this.lblPricePerLitre.TabIndex = 9;
            this.lblPricePerLitre.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Price per Litre:";
            // 
            // lblPumpState
            // 
            this.lblPumpState.AutoSize = true;
            this.lblPumpState.Location = new System.Drawing.Point(236, 28);
            this.lblPumpState.Name = "lblPumpState";
            this.lblPumpState.Size = new System.Drawing.Size(0, 13);
            this.lblPumpState.TabIndex = 5;
            // 
            // lblPumpStateDescription
            // 
            this.lblPumpStateDescription.AutoSize = true;
            this.lblPumpStateDescription.Location = new System.Drawing.Point(153, 28);
            this.lblPumpStateDescription.Name = "lblPumpStateDescription";
            this.lblPumpStateDescription.Size = new System.Drawing.Size(68, 13);
            this.lblPumpStateDescription.TabIndex = 4;
            this.lblPumpStateDescription.Text = "Pump State: ";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(3, 135);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(144, 38);
            this.btnReplace.TabIndex = 3;
            this.btnReplace.Text = "Replace Nozzle";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(3, 91);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 38);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Dispensing";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 38);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Dispensing";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLift
            // 
            this.btnLift.Location = new System.Drawing.Point(3, 3);
            this.btnLift.Name = "btnLift";
            this.btnLift.Size = new System.Drawing.Size(144, 38);
            this.btnLift.TabIndex = 0;
            this.btnLift.Text = "Lift Nozzle";
            this.btnLift.UseVisualStyleBackColor = true;
            this.btnLift.Click += new System.EventHandler(this.btnLift_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 588);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPumpState;
        private System.Windows.Forms.Label lblPumpStateDescription;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPricePerLitre;
    }
}

