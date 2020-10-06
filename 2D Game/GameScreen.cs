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
        SoundPlayer victorySound = new SoundPlayer(Properties.Resources.victorySound);
        SoundPlayer lossSound = new SoundPlayer(Properties.Resources.lossSound);

        //check if a new game is started

        // draws boxes
        SolidBrush heroBrush = new SolidBrush(Color.Green);
        SolidBrush obstacleBrush = new SolidBrush(Color.Red);
        SolidBrush objectiveBrush = new SolidBrush(Color.Yellow);

        List<Obstacles> left = new List<Obstacles>();
        List<Obstacles> right = new List<Obstacles>();
        List<Obstacles> middle = new List<Obstacles>();

        Obstacles hero;
        int heroSpeed = 6;
        int heroSize = 35;

        int counter = 0;

        Obstacles objective;
        int objectiveSize = 60;

        Random randGen = new Random();
        

        

        int leftI = 250;
        int leftII = 0;
        int leftIII = 532;
        int gap = 300;
        Boolean moveRight;

        int patternLength = 20;
        int patternSpeed = 7;

        public GameScreen()
        {
            InitializeComponent();
            Onstart();
        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            

        }
        public void Onstart()
        {
            MakeObstacle();

            Color c = Color.Red;
            Color b = Color.Yellow;
            hero = new Obstacles(50 - heroSize / 2, 222, heroSize, c);
            objective = new Obstacles(50 - objectiveSize / 2, 222, objectiveSize, b);
        }

        public void MakeObstacle()
        {
           
            Color c = Color.Red;


            //patternLength--;

            //if(patternLength == 0)
            //{
            //    //moveRight = !moveRight;

            //    patternLength = randGen.Next(1, 9);
            //}

            //if (moveRight == true)
            //{
            //    leftI += 7;
            //}
            //else
            //{
            //    leftI -= 7;
            //}
            if (counter % 75 == 0)
            {


                Obstacles newobstacle = new Obstacles(leftI, leftIII, 20, c);
               
               
                left.Add(newobstacle);

                Obstacles newobstacle3 = new Obstacles(400, leftII, 20, c);
                middle.Add(newobstacle3);

                Obstacles newobstacle2 = new Obstacles(leftI + gap, leftIII, 20, c);
                right.Add(newobstacle2);

            }
            //if (counter % 80 == 0)
            //{
                
            //}
            //if(counter % 90 == 0)
            //{
                
            //}
            counter++;
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void GameScreen_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (counter > 200)
            {
                waitLabel.Visible = false;

                switch (e.KeyCode)
                { 
                    case Keys.W:
                        wKeyDown = true;
                        break;
                    case Keys.A:
                        aKeyDown = true;
                        break;
                    case Keys.S:
                        sKeyDown = true;
                        break;
                    case Keys.D:
                        dKeyDown = true;
                        break;
                }
            }
        }

        private void gameLoop_Tick_1(object sender, EventArgs e)
        {

            foreach (Obstacles b in left)
            {
                b.Move(-5);
            }
            foreach (Obstacles b in right)
            {
                b.Move(-5);
            }

            foreach (Obstacles b in middle)
            {
                b.Move(5);
            }
            //remove box if it has gone of screen
            if (left[0].y < 0)
            {
                left.RemoveAt(0);
            }
            if (right[0].y < 0)
            {
                right.RemoveAt(0);
            }
            if (middle[0].y > this.Height)
            {
                middle.RemoveAt(0);
            }
            //add new box if it is time
            if (left[left.Count - 1].y > 21)
            {
                MakeObstacle();
            }
            if (right[right.Count - 1].y > 21)
            {
                MakeObstacle();
            }
            if(middle[middle.Count - 1].y > 21)
            {
                MakeObstacle();
            }

 

            if (aKeyDown == true)
            {
                hero.Move(heroSpeed, false);
            }
            if (dKeyDown == true)
            {
                hero.Move(heroSpeed, true);
            }
            if (wKeyDown == true && hero.y >= 0)
            {
                hero.Move2(heroSpeed, false);
            }
            if (sKeyDown == true && hero.y + 50 <= this.Height)
            {
                hero.Move2(heroSpeed, true);
            }

            

            Rectangle heroRec = new Rectangle(hero.x, hero.y, hero.size, hero.size);

            if (left.Count >= 4)
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    Rectangle obstacleRec = new Rectangle(left[i].x, left[i].y, left[i].size, left[i].size);
                    Rectangle rightobstacleRec = new Rectangle(right[i].x, right[i].y, right[i].size, right[i].size);
                    Rectangle middleobstacleRec = new Rectangle(middle[i].x, middle[i].y, middle[i].size, middle[i].size);
                    Rectangle objectiveRec = new Rectangle(835, 250, objectiveSize, objectiveSize);

                    if (obstacleRec.IntersectsWith(heroRec) || rightobstacleRec.IntersectsWith(heroRec) || middleobstacleRec.IntersectsWith(heroRec))
                    {
                        gameLoop.Enabled = false;

                        lossLabel.Text = "YOU LOSE";
                        lossSound.Play();

                        Refresh();
                        Thread.Sleep(1000);

                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        MainScreen ss = new MainScreen();
                        f.Controls.Add(ss);
                        ss.Focus();
                    }
                    else  if (objectiveRec.IntersectsWith(heroRec))
                    {
                        gameLoop.Stop();
                        victorylabel.Text = "YOU WIN";
                        victorySound.Play();

                        Refresh();
                        Thread.Sleep(3000);

                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        MainScreen ss = new MainScreen();
                        f.Controls.Add(ss);
                        ss.Focus();
                        return;
                    }
                }
            }

            Refresh();
        }

        

        private void GameScreen_Load(object sender, EventArgs e)
        {
            victorylabel.Text = "";
            lossLabel.Text = "";
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

            foreach (Obstacles b in middle)
            {
                obstacleBrush.Color = b.color;
                e.Graphics.FillRectangle(obstacleBrush, b.x, b.y, b.size, b.size);
            }

            //draw hero character
            e.Graphics.DrawImage(Properties.Resources.heroFace, hero.x, hero.y, hero.size, hero.size);

            //draw objective
            e.Graphics.DrawImage(Properties.Resources.trophyImage, 835, 250, objective.size, objective.size);

            e.Graphics.DrawImage(Properties.Resources.villianFace, 820, 170);
        }
    }
}
