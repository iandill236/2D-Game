using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Game
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            // Create an instance of the GameScreen 

            GameScreen ss = new GameScreen();


            // Add the User Control to the Form 

            f.Controls.Add(ss);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.swordImage, 0, 50, 500, 500);
        }
    }
}
