using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Square_Chasing
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(20, 20, 20, 20);
        Rectangle player2 = new Rectangle(360, 360, 20, 20);
        Rectangle booster = new Rectangle(0, 0, 10, 10);
        Rectangle pointUp = new Rectangle(0, 0, 10, 10);
        Rectangle pointDown = new Rectangle(0, 0, 20, 20);

        int player1Speed = 4;
        int player2Speed = 4;
        int player1Score = 0;
        int player2Score = 0;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        bool space = false;

        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush magentaBrush = new SolidBrush(Color.Magenta);

        SoundPlayer Bing = new SoundPlayer(Properties.Resources.bing);
        SoundPlayer Applause = new SoundPlayer(Properties.Resources.applause);

        Pen yellowPen = new Pen(Color.Yellow);
        Pen redPen = new Pen(Color.Red, 3);

        Random randGen = new Random();

        public Form1()
        {
            InitializeComponent();

            GameInitialize();
        }

        public void GameInitialize()
        {


            int xb = randGen.Next(0, 400 - booster.Height);
            int yb = randGen.Next(0, 400 - booster.Height);
            booster.X = xb;
            booster.Y = yb;

            int xup = randGen.Next(0, 400 - pointUp.Height);
            int yup = randGen.Next(0, 400 - pointUp.Height);
            pointUp.X = xup;
            pointUp.Y = yup;

            int xdown = randGen.Next(0, 400 - pointDown.Height);
            int ydown = randGen.Next(0, 400 - pointDown.Height);
            pointDown.X = xdown;
            pointDown.Y = ydown;

            while (pointUp.IntersectsWith(booster) || pointUp.IntersectsWith(pointDown))
            {
                xup = randGen.Next(0, 400 - pointUp.Height);
                yup = randGen.Next(0, 400 - pointUp.Height);
                pointUp.X = xup;
                pointUp.Y = yup;
            }
            while (pointDown.IntersectsWith(booster) || pointDown.IntersectsWith(pointUp))
            {
                xdown = randGen.Next(0, 400 - pointDown.Height);
                ydown = randGen.Next(0, 400 - pointDown.Height);
                pointDown.X = xdown;
                pointDown.Y = ydown;
            }

            player1Score = 0;
            player2Score = 0;
            p1Score.Text = "0";
            p2Score.Text = "0";
            winLable.Text = "";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                // add a case for space
                //if game engine enabled is false
                // call Game Initialize
                // start game engine
                case Keys.Space:
                    //space = true;
                    if (gameEngine.Enabled == false)
                    {
                        gameEngine.Enabled = true;
                        GameInitialize();
                    }
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Space:
                    space = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(magentaBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, pointUp);
            e.Graphics.DrawRectangle(yellowPen, booster);
            e.Graphics.DrawRectangle(redPen, pointDown);
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Height - player1.Height)
            {
                player1.X += player1Speed;
            }

            //move player2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            if (player1.IntersectsWith(pointUp))
            {
                player1Score++;
                p1Score.Text = $"{player1Score}";
                Bing.Play();

                int xup = randGen.Next(0, 400 - pointUp.Height);
                int yup = randGen.Next(0, 400 - pointUp.Height);
                pointUp.X = xup;
                pointUp.Y = yup;
            }

            if (player2.IntersectsWith(pointUp))
            {
                player2Score++;
                p2Score.Text = $"{player2Score}";
                Bing.Play();

                int xup = randGen.Next(0, 400 - pointUp.Height);
                int yup = randGen.Next(0, 400 - pointUp.Height);
                pointUp.X = xup;
                pointUp.Y = yup;
            }

            if (player1.IntersectsWith(booster))
            {
                player1Speed++;

                int xb = randGen.Next(0, 400 - booster.Height);
                int yb = randGen.Next(0, 400 - booster.Height);
                booster.X = xb;
                booster.Y = yb;
            }

            if (player2.IntersectsWith(booster))
            {
                player2Speed++;

                int xb = randGen.Next(0, 400 - booster.Height);
                int yb = randGen.Next(0, 400 - booster.Height);
                booster.X = xb;
                booster.Y = yb;
            }

            if (player1.IntersectsWith(pointDown))
            {
                player1Speed--;
                player1Score--;
                p1Score.Text = $"{player1Score}";

                int xdown = randGen.Next(0, 400 - pointDown.Height);
                int ydown = randGen.Next(0, 400 - pointDown.Height);
                pointDown.X = xdown;
                pointDown.Y = ydown;
            }

            if (player2.IntersectsWith(pointDown))
            {
                player2Speed--;
                player2Score--;
                p2Score.Text = $"{player2Score}";

                int xdown = randGen.Next(0, 400 - pointDown.Height);
                int ydown = randGen.Next(0, 400 - pointDown.Height);
                pointDown.X = xdown;
                pointDown.Y = ydown;
            }

            if (player1Score == 5)
            {
                //stop game engine
                gameEngine.Enabled = false;
                winLable.Text = "Player 1 wins";
                Applause.Play();
            }

            else if (player2Score == 5)
            {
                gameEngine.Enabled = false;
                winLable.Text = "Player 2 wins";
                Applause.Play();
            }

            Refresh();

            if (gameEngine.Enabled == false && space == true)
            {


            }
        }
    }
}

