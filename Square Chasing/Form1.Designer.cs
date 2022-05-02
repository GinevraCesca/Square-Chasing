namespace Square_Chasing
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
            this.components = new System.ComponentModel.Container();
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.p1Score = new System.Windows.Forms.Label();
            this.p2Score = new System.Windows.Forms.Label();
            this.winLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Enabled = true;
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // p1Score
            // 
            this.p1Score.BackColor = System.Drawing.Color.Transparent;
            this.p1Score.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Score.Location = new System.Drawing.Point(144, 9);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(34, 23);
            this.p1Score.TabIndex = 0;
            this.p1Score.Text = "0";
            this.p1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2Score
            // 
            this.p2Score.BackColor = System.Drawing.Color.Transparent;
            this.p2Score.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Score.Location = new System.Drawing.Point(214, 9);
            this.p2Score.Name = "p2Score";
            this.p2Score.Size = new System.Drawing.Size(34, 23);
            this.p2Score.TabIndex = 1;
            this.p2Score.Text = "0";
            this.p2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLable
            // 
            this.winLable.BackColor = System.Drawing.Color.Transparent;
            this.winLable.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLable.Location = new System.Drawing.Point(95, 187);
            this.winLable.Name = "winLable";
            this.winLable.Size = new System.Drawing.Size(208, 30);
            this.winLable.TabIndex = 2;
            this.winLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.winLable);
            this.Controls.Add(this.p2Score);
            this.Controls.Add(this.p1Score);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Square Chaser";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label p2Score;
        private System.Windows.Forms.Label winLable;
    }
}

