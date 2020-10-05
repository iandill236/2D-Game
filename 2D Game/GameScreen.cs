using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Security.Cryptography;

namespace _2D_Game
{
    public partial class GameScreen : UserControl
    {
        // checks if a key is being pressed
        Boolean wKeyDown, aKeyDown, sKeyDown, dKeyDown;

        //Sounds

        //check if a new game is started

        // draws boxes
        SolidBrush heroBrush = new SolidBrush(Color.Green);
        SolidBrush obstacleBrush = new SolidBrush(Color.Red);

        List<Obstacles> left = new List<Obstacles>();
        List<Obstacles> right = new List<Obstacles>();

        Obstacles hero;
        int heroSpeed = 5;
        int heroSize = 10;

        Random randGen = new Random();

        int leftMoveCounter, rightMoveCounter = 0;

        int leftI = 250;
        int gap = 300;
        Boolean moveRight;

        int patternLength = 20;
        int patternSpeed = 7;

        public GameScreen()
        {
            InitializeComponent();
            Onstart();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    wKeyDown = true;
                    break;
                case Keys.Z:
                    aKeyDown = true;
                    break;
                case Keys.J:
                    sKeyDown = true;
                    break;
                case Keys.M:
                    dKeyDown = true;
                    break;
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    wKeyDown = false;
                    break;
                case Keys.Z:
                    aKeyDown = false;
                    break;
                case Keys.J:
                    sKeyDown = false;
                    break;
                case Keys.M:
                    dKeyDown = false;
                    break;
            }

        }
        public void Onstart()
        {
            MakeObstacle();

            Color c = Color.Red;
            hero = new Obstacles(this.Width / 2 - heroSize / 2, 445, heroSize, c);
        }

        public void MakeObstacle()
        {
           
            Color c = Color.Red;


            patternLength--;

            if(patternLength == 0)
            {
                moveRight = !moveRight;

                patternLength = randGen.Next(1, 9);
            }

            if (moveRight == true)
            {
                leftI += patternSpeed;
            }
            else
            {
                leftI -= patternSpeed;
            }

          Obstacles newobstacle = new Obstacles(leftI, 0, 20, c);
          Obstacles newobstacle2 = new Obstacles(leftI + gap, 0, 20, c);
          left.Add(newobstacle);
          right.Add(newobstacle2);
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            leftMoveCounter++;
            rightMoveCounter++;

            foreach (Obstacles b in left)
            {
                b.Move(10);
            }
            foreach (Obstacles b in right)
            {
                b.Move(10);
            }
            //remove box if it has gone of screen
            if (left[0].y > this.Height)
            {
                left.RemoveAt(0);
            }
            if (right[0].y > this.Height)
            {
                right.RemoveAt(0);
            }
            //add new box if it is time
            if (leftMoveCounter > 2)
            {
                leftMoveCounter = 0;
                MakeObstacle();
            }
            if (rightMoveCounter > 2)
            {
                rightMoveCounter = 0;
                MakeObstacle();
            }


            if (aKeyDown == true)
            {
                hero.Move(heroSpeed, false);
            }
            else if (dKeyDown == true)
            {
                hero.Move(heroSpeed, true);
            }
            if (wKeyDown == true)
            {
                hero.Move2(heroSpeed, false);
            }
            if (sKeyDown == true)
            {
                hero.Move2(heroSpeed, true);
            }

            Rectangle heroRec = new Rectangle(hero.x, hero.y, hero.size, hero.size);

            if (left.Count >= 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    Rectangle obstacleRec = new Rectangle(left[i].x, left[i].y, left[i].size, left[i].size);
                    Rectangle rightobstacleRec = new Rectangle(right[i].x, right[i].y, right[i].size, right[i].size);

                    if (obstacleRec.IntersectsWith(heroRec) || rightobstacleRec.IntersectsWith(heroRec))
                    {
                       //gameLoop.Enabled = false;
                    }
                }
            }

            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw boxes to screen
            foreach (Obstacles b in left)
            {
                obstacleBrush.Color = b.color;
                e.Graphics.FillRectangle(obstacleBrush, b.x, b.y, b.size, b.size);
            }

            foreach (Obstacles b in right)
            {
                obstacleBrush.Color = b.color;
                e.Graphics.FillRectangle(obstacleBrush, b.x, b.y, b.size, b.size);
            }

            //draw hero character
            e.Graphics.FillRectangle(heroBrush, hero.x, hero.y, hero.size, hero.size);
        }
    }
}
