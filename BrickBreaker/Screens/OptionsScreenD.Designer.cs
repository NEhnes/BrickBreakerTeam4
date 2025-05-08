namespace BrickBreaker.Screens
{
    partial class OptionsScreenD
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backButton = new System.Windows.Forms.Button();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.darkCheck = new System.Windows.Forms.CheckBox();
            this.lightCheck = new System.Windows.Forms.CheckBox();
            this.lightDisplay = new System.Windows.Forms.Label();
            this.darkDisplay = new System.Windows.Forms.Label();
            this.themeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("DynaPuff", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(127)))), ((int)(((byte)(113)))));
            this.backButton.Location = new System.Drawing.Point(462, 552);
            this.backButton.Margin = new System.Windows.Forms.Padding(0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(129, 52);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // creditsLabel
            // 
            this.creditsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(155)))));
            this.creditsLabel.Font = new System.Drawing.Font("DynaPuff Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.creditsLabel.Location = new System.Drawing.Point(164, 379);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(129, 43);
            this.creditsLabel.TabIndex = 15;
            this.creditsLabel.Text = "Credits";
            this.creditsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.creditsLabel.Click += new System.EventHandler(this.creditsLabel_Click);
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(206)))), ((int)(((byte)(170)))));
            this.highScoreLabel.Font = new System.Drawing.Font("DynaPuff Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(22)))), ((int)(((byte)(112)))));
            this.highScoreLabel.Location = new System.Drawing.Point(774, 379);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(129, 43);
            this.highScoreLabel.TabIndex = 14;
            this.highScoreLabel.Text = "High Scores";
            this.highScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkCheck
            // 
            this.darkCheck.AutoSize = true;
            this.darkCheck.Location = new System.Drawing.Point(774, 238);
            this.darkCheck.Name = "darkCheck";
            this.darkCheck.Size = new System.Drawing.Size(18, 17);
            this.darkCheck.TabIndex = 13;
            this.darkCheck.UseVisualStyleBackColor = true;
            // 
            // lightCheck
            // 
            this.lightCheck.AutoSize = true;
            this.lightCheck.Location = new System.Drawing.Point(434, 238);
            this.lightCheck.Name = "lightCheck";
            this.lightCheck.Size = new System.Drawing.Size(18, 17);
            this.lightCheck.TabIndex = 12;
            this.lightCheck.UseVisualStyleBackColor = true;
            this.lightCheck.CheckedChanged += new System.EventHandler(this.lightCheck_CheckedChanged);
            // 
            // lightDisplay
            // 
            this.lightDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(206)))), ((int)(((byte)(170)))));
            this.lightDisplay.Font = new System.Drawing.Font("DynaPuff Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(22)))), ((int)(((byte)(112)))));
            this.lightDisplay.Location = new System.Drawing.Point(299, 223);
            this.lightDisplay.Name = "lightDisplay";
            this.lightDisplay.Size = new System.Drawing.Size(129, 43);
            this.lightDisplay.TabIndex = 11;
            this.lightDisplay.Text = "Theme";
            this.lightDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkDisplay
            // 
            this.darkDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(155)))));
            this.darkDisplay.Font = new System.Drawing.Font("DynaPuff Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.darkDisplay.Location = new System.Drawing.Point(639, 223);
            this.darkDisplay.Name = "darkDisplay";
            this.darkDisplay.Size = new System.Drawing.Size(129, 43);
            this.darkDisplay.TabIndex = 10;
            this.darkDisplay.Text = "Theme";
            this.darkDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // themeLable
            // 
            this.themeLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(127)))), ((int)(((byte)(113)))));
            this.themeLable.Font = new System.Drawing.Font("DynaPuff Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.themeLable.Location = new System.Drawing.Point(462, 72);
            this.themeLable.Name = "themeLable";
            this.themeLable.Size = new System.Drawing.Size(129, 64);
            this.themeLable.TabIndex = 9;
            this.themeLable.Text = "Theme";
            this.themeLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionsScreenD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(7)))), ((int)(((byte)(112)))));
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.darkCheck);
            this.Controls.Add(this.lightCheck);
            this.Controls.Add(this.lightDisplay);
            this.Controls.Add(this.darkDisplay);
            this.Controls.Add(this.themeLable);
            this.Name = "OptionsScreenD";
            this.Size = new System.Drawing.Size(1067, 677);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.CheckBox darkCheck;
        private System.Windows.Forms.CheckBox lightCheck;
        private System.Windows.Forms.Label lightDisplay;
        private System.Windows.Forms.Label darkDisplay;
        private System.Windows.Forms.Label themeLable;
    }
}
