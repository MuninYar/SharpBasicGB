namespace GuessingGame
{
    partial class GuessingGame
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
            this.textBoxUserInput = new System.Windows.Forms.TextBox();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.labelRules = new System.Windows.Forms.Label();
            this.labelHigher = new System.Windows.Forms.Label();
            this.labelLesser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUserInput
            // 
            this.textBoxUserInput.AcceptsReturn = true;
            this.textBoxUserInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUserInput.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUserInput.Location = new System.Drawing.Point(218, 181);
            this.textBoxUserInput.Name = "textBoxUserInput";
            this.textBoxUserInput.Size = new System.Drawing.Size(72, 20);
            this.textBoxUserInput.TabIndex = 0;
            this.textBoxUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserInput_KeyDown);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Cursor = System.Windows.Forms.Cursors.Cross;
            this.buttonNewGame.Location = new System.Drawing.Point(191, 53);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(123, 47);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // labelRules
            // 
            this.labelRules.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelRules.Location = new System.Drawing.Point(142, 132);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(233, 20);
            this.labelRules.TabIndex = 2;
            this.labelRules.Text = "Угадай число от 1 до 100!";
            // 
            // labelHigher
            // 
            this.labelHigher.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelHigher.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHigher.Location = new System.Drawing.Point(331, 181);
            this.labelHigher.Name = "labelHigher";
            this.labelHigher.Size = new System.Drawing.Size(129, 33);
            this.labelHigher.TabIndex = 3;
            this.labelHigher.Text = "МНОГО!";
            // 
            // labelLesser
            // 
            this.labelLesser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelLesser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLesser.Location = new System.Drawing.Point(63, 181);
            this.labelLesser.Name = "labelLesser";
            this.labelLesser.Size = new System.Drawing.Size(108, 33);
            this.labelLesser.TabIndex = 4;
            this.labelLesser.Text = "МАЛО!";
            // 
            // GuessingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(537, 332);
            this.Controls.Add(this.labelLesser);
            this.Controls.Add(this.labelHigher);
            this.Controls.Add(this.labelRules);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.textBoxUserInput);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "GuessingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelHigher;
        private System.Windows.Forms.Label labelLesser;

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label labelRules;

        private System.Windows.Forms.TextBox textBoxUserInput;

        #endregion
    }
}