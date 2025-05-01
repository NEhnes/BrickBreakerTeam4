namespace BrickBreaker
{
    partial class MenuScreen
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
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(153)))));
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(153)))));
            this.playButton.Location = new System.Drawing.Point(412, 100);
            this.playButton.Margin = new System.Windows.Forms.Padding(4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(242, 96);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.Enter += new System.EventHandler(this.playButton_Enter);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_Enter);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(153)))));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(153)))));
            this.exitButton.Location = new System.Drawing.Point(412, 323);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(242, 96);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(153)))));
            this.optionsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.optionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optionsButton.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
            this.optionsButton.Location = new System.Drawing.Point(412, 563);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(4);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(242, 60);
            this.optionsButton.TabIndex = 2;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            this.optionsButton.Enter += new System.EventHandler(this.optionsButton_Enter);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1067, 677);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button optionsButton;
    }
}
