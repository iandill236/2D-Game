namespace _2D_Game
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.victorylabel = new System.Windows.Forms.Label();
            this.lossLabel = new System.Windows.Forms.Label();
            this.waitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 15;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick_1);
            // 
            // victorylabel
            // 
            this.victorylabel.AutoSize = true;
            this.victorylabel.BackColor = System.Drawing.Color.Transparent;
            this.victorylabel.Font = new System.Drawing.Font("Poor Richard", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victorylabel.ForeColor = System.Drawing.Color.Gold;
            this.victorylabel.Location = new System.Drawing.Point(768, 65);
            this.victorylabel.Name = "victorylabel";
            this.victorylabel.Size = new System.Drawing.Size(181, 44);
            this.victorylabel.TabIndex = 0;
            this.victorylabel.Text = "YOU WIN";
            // 
            // lossLabel
            // 
            this.lossLabel.AutoSize = true;
            this.lossLabel.BackColor = System.Drawing.Color.Transparent;
            this.lossLabel.Font = new System.Drawing.Font("Poor Richard", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lossLabel.ForeColor = System.Drawing.Color.Gold;
            this.lossLabel.Location = new System.Drawing.Point(755, 12);
            this.lossLabel.Name = "lossLabel";
            this.lossLabel.Size = new System.Drawing.Size(194, 44);
            this.lossLabel.TabIndex = 1;
            this.lossLabel.Text = "YOU LOSE";
            // 
            // waitLabel
            // 
            this.waitLabel.AutoSize = true;
            this.waitLabel.BackColor = System.Drawing.Color.Transparent;
            this.waitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLabel.ForeColor = System.Drawing.Color.Red;
            this.waitLabel.Location = new System.Drawing.Point(17, 124);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(172, 54);
            this.waitLabel.TabIndex = 2;
            this.waitLabel.Text = "Wait a few seconds\r\n\r\nPress WASD to move";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.lossLabel);
            this.Controls.Add(this.victorylabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(969, 532);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp_1);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label victorylabel;
        private System.Windows.Forms.Label lossLabel;
        private System.Windows.Forms.Label waitLabel;
    }
}
