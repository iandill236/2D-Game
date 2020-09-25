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
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender,KeyEventArgs e)
        {

        }


        public void Onstart()
        {

        }

        private void gameTimer_tick(object sender, EventArgs e)
        {
            //update movement of enemies

            //update movement of hero

            //check for collision
            
            
            
            
            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
