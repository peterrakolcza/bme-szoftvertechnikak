namespace MultiThreadedApp
{
    partial class MainForm_IMO7KC
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bBike1 = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.pTarget = new System.Windows.Forms.Panel();
            this.bStep = new System.Windows.Forms.Button();
            this.bBike2 = new System.Windows.Forms.Button();
            this.bBike3 = new System.Windows.Forms.Button();
            this.pStart = new System.Windows.Forms.Panel();
            this.pDepo = new System.Windows.Forms.Panel();
            this.bStep2 = new System.Windows.Forms.Button();
            this.bDistance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bBike1
            // 
            this.bBike1.Font = new System.Drawing.Font("Webdings", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bBike1.Location = new System.Drawing.Point(58, 47);
            this.bBike1.Name = "bBike1";
            this.bBike1.Size = new System.Drawing.Size(75, 69);
            this.bBike1.TabIndex = 0;
            this.bBike1.Text = "b";
            this.bBike1.UseVisualStyleBackColor = true;
            this.bBike1.Click += new System.EventHandler(this.bBike_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(58, 403);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(127, 56);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pTarget
            // 
            this.pTarget.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pTarget.Location = new System.Drawing.Point(639, 36);
            this.pTarget.Name = "pTarget";
            this.pTarget.Size = new System.Drawing.Size(120, 230);
            this.pTarget.TabIndex = 2;
            // 
            // bStep
            // 
            this.bStep.Location = new System.Drawing.Point(223, 403);
            this.bStep.Name = "bStep";
            this.bStep.Size = new System.Drawing.Size(127, 56);
            this.bStep.TabIndex = 3;
            this.bStep.Text = "Step1";
            this.bStep.UseVisualStyleBackColor = true;
            this.bStep.Click += new System.EventHandler(this.bStep_Click);
            // 
            // bBike2
            // 
            this.bBike2.Font = new System.Drawing.Font("Webdings", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bBike2.Location = new System.Drawing.Point(58, 122);
            this.bBike2.Name = "bBike2";
            this.bBike2.Size = new System.Drawing.Size(75, 69);
            this.bBike2.TabIndex = 4;
            this.bBike2.Text = "b";
            this.bBike2.UseVisualStyleBackColor = true;
            this.bBike2.Click += new System.EventHandler(this.bBike_Click);
            // 
            // bBike3
            // 
            this.bBike3.Font = new System.Drawing.Font("Webdings", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bBike3.Location = new System.Drawing.Point(58, 197);
            this.bBike3.Name = "bBike3";
            this.bBike3.Size = new System.Drawing.Size(75, 69);
            this.bBike3.TabIndex = 5;
            this.bBike3.Text = "b";
            this.bBike3.UseVisualStyleBackColor = true;
            this.bBike3.Click += new System.EventHandler(this.bBike_Click);
            // 
            // pStart
            // 
            this.pStart.BackColor = System.Drawing.Color.SteelBlue;
            this.pStart.Location = new System.Drawing.Point(223, 36);
            this.pStart.Name = "pStart";
            this.pStart.Size = new System.Drawing.Size(127, 230);
            this.pStart.TabIndex = 3;
            // 
            // pDepo
            // 
            this.pDepo.BackColor = System.Drawing.Color.SteelBlue;
            this.pDepo.Location = new System.Drawing.Point(428, 36);
            this.pDepo.Name = "pDepo";
            this.pDepo.Size = new System.Drawing.Size(127, 230);
            this.pDepo.TabIndex = 4;
            // 
            // bStep2
            // 
            this.bStep2.Location = new System.Drawing.Point(428, 403);
            this.bStep2.Name = "bStep2";
            this.bStep2.Size = new System.Drawing.Size(127, 56);
            this.bStep2.TabIndex = 6;
            this.bStep2.Text = "Step2";
            this.bStep2.UseVisualStyleBackColor = true;
            this.bStep2.Click += new System.EventHandler(this.bStep2_Click);
            // 
            // bDistance
            // 
            this.bDistance.Location = new System.Drawing.Point(639, 403);
            this.bDistance.Name = "bDistance";
            this.bDistance.Size = new System.Drawing.Size(120, 56);
            this.bDistance.TabIndex = 7;
            this.bDistance.Text = "Distance";
            this.bDistance.UseVisualStyleBackColor = true;
            this.bDistance.Click += new System.EventHandler(this.bDistance_Click);
            // 
            // MainForm_IMO7KC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.bDistance);
            this.Controls.Add(this.bStep2);
            this.Controls.Add(this.bBike3);
            this.Controls.Add(this.bBike2);
            this.Controls.Add(this.bStep);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bBike1);
            this.Controls.Add(this.pStart);
            this.Controls.Add(this.pTarget);
            this.Controls.Add(this.pDepo);
            this.Name = "MainForm_IMO7KC";
            this.Text = "Tour de France - IMO7KC";
            this.ResumeLayout(false);

        }

        #endregion

        private Button bBike1;
        private Button bStart;
        private Panel pTarget;
        private Button bStep;
        private Button bBike2;
        private Button bBike3;
        private Panel pStart;
        private Panel pDepo;
        private Button bStep2;
        private Button bDistance;
    }
}