namespace GenreRecognizer
{
    partial class GenreRecognitionForm
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
            this.RecognizeButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TrainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RecognizeButton
            // 
            this.RecognizeButton.Location = new System.Drawing.Point(204, 142);
            this.RecognizeButton.Name = "RecognizeButton";
            this.RecognizeButton.Size = new System.Drawing.Size(125, 23);
            this.RecognizeButton.TabIndex = 0;
            this.RecognizeButton.Text = "Recognize genre";
            this.RecognizeButton.UseVisualStyleBackColor = true;
            this.RecognizeButton.Click += new System.EventHandler(this.RecognizeButtonClick);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(204, 104);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(125, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.TabIndex = 1;
            this.ProgressBar.Visible = false;
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(204, 171);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(125, 23);
            this.TrainButton.TabIndex = 2;
            this.TrainButton.Text = "Train NN";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButtonClick);
            // 
            // GenreRecognitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 281);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.RecognizeButton);
            this.Name = "GenreRecognitionForm";
            this.Text = "GenreRecognition";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RecognizeButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button TrainButton;
    }
}

