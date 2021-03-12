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

namespace air_hockey_
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Ryan Prosper,March,12,2021
        /// The Code is a simple Air Hockey Table Game 
        /// </summary>
        int paddle1X = 110;
        int paddle1Y = 180;
        int player1Score = 0;

        int paddle2X = 460;
        int paddle2Y = 180;
        int player2Score = 0;

        int paddleWidth = 40;
        int paddleHeight = 40;
        int paddleSpeed = 4;

        int ballX = 292;
        int ballY = 195;
        int ballXSpeed = 6;
        int ballYSpeed = 6;
        int ballWidth = 14;
        int ballHeight = 14;


        bool rightDown = false;
        bool leftDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool wDown = false;
        bool sDown = false;

        SolidBrush midLine = new SolidBrush(Color.DarkGray);
        SolidBrush p2 = new SolidBrush(Color.Blue);
        SolidBrush p1 = new SolidBrush(Color.DarkRed);
        SolidBrush walls = new SolidBrush(Color.White);
        Pen nets = new Pen(Color.White);

        SoundPlayer sound = new SoundPlayer(Properties.Resources.Hockey);
        SoundPlayer airHorn = new SoundPlayer(Properties.Resources.Air_Horn);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Set All Keys
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }
        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw All Box's
            e.Graphics.DrawRectangle(nets, 0, 150, 20, 100);

            e.Graphics.DrawRectangle(nets, 562, 150, 20, 100);

            e.Graphics.FillRectangle(walls, 0, 250, 15, 150);

            e.Graphics.FillRectangle(walls, 0, 1, 15, 150);

            e.Graphics.FillRectangle(walls, 0, 1, 585, 15);

            e.Graphics.FillRectangle(walls, 570, 250, 15, 150);

            e.Graphics.FillRectangle(walls, 570, 1, 15, 150);

            e.Graphics.FillRectangle(walls, 0, 400, 585, 15);

            e.Graphics.FillRectangle(midLine, 295, 16, 10, 384);

            e.Graphics.FillEllipse(walls, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.DrawEllipse(nets, 269, 167, 60, 60);

            e.Graphics.FillEllipse(p1, paddle1X, paddle1Y, paddleWidth, paddleHeight);

            e.Graphics.FillEllipse(p2, paddle2X, paddle2Y, paddleWidth, paddleHeight);
        }

        private void Timer(object sender, EventArgs e)
        {
            //move ball
            ballX += ballXSpeed;
            ballY += ballYSpeed;

            //move player 1 
            if (wDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
            }

            if (sDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed;
            }

            if (aDown == true && paddle1X > 0)
            {
                paddle1X -= paddleSpeed;
            }
            if (dDown == true && paddle1X < this.Width - paddleWidth)
            {
                paddle1X += paddleSpeed;
            }

            //move player 2 
            if (upArrowDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
            }

            if (downArrowDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
            }
            if (leftDown == true && paddle2X > 0)
            {
                paddle2X -= paddleSpeed;
            }
            if (rightDown == true && paddle2X < this.Width - paddleWidth)
            {
                paddle2X += paddleSpeed;
            }

            if (ballY < 0 || ballY > this.Height - ballHeight)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }

            //create the Colison For all items 

            Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            Rectangle wallRec1 = new Rectangle(0, 250, 15, 150);
            Rectangle wallRec2 = new Rectangle(0, 1, 15, 150);
            Rectangle wallRec3 = new Rectangle(0, 1, 600, 15);
            Rectangle wallRec4 = new Rectangle(570, 250, 15, 150);
            Rectangle wallRec5 = new Rectangle(570, 1, 15, 150);
            Rectangle wallRec6 = new Rectangle(0, 400, 600, 15);
            Rectangle net1 = new Rectangle(0, 150, 20, 100);
            Rectangle net2 = new Rectangle(562, 150, 20, 100);
            Rectangle mid = new Rectangle(295, 16, 10, 384);
            Rectangle midOval = new Rectangle(269, 167, 60, 60);

            //Set Colison For Player 1
            if (player1Rec.IntersectsWith(ballRec))
            {
                sound.Play();
                ballXSpeed *= +1;
                ballX = paddle1X + paddleWidth + 1;
            }
            if (player1Rec.IntersectsWith(mid))
            {
                paddle1X = paddle1X - paddleWidth -1;
            }
            if (player1Rec.IntersectsWith(wallRec1))
            {
                paddle1X = paddle1X + paddleWidth +1;
            }
            if (player1Rec.IntersectsWith(wallRec3))
            {
                paddle1Y = paddle1Y + paddleWidth -1;
            }
            if (player1Rec.IntersectsWith(wallRec6))
            {
                paddle1Y = paddle1Y - paddleWidth +1;
            }
            if (player1Rec.IntersectsWith(wallRec2))
            {
                paddle1Y = paddle1Y + paddleWidth - 1;
            }
            if (player1Rec.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = paddle1X + paddleWidth + 1;
            }


            //Set Colison For Player 2
            if (player2Rec.IntersectsWith(ballRec))
            {
                sound.Play();
                ballXSpeed *= -1;
                ballX = paddle2X - paddleWidth - 1;
            }
            if (player2Rec.IntersectsWith(mid))
            {
                paddle2X = paddle2X + paddleWidth + 1;
            }
            if (player2Rec.IntersectsWith(wallRec3))
            {
                paddle2Y = paddle2Y + paddleWidth -1;
            }
            if (player2Rec.IntersectsWith(wallRec4))
            {
                paddle2X = paddle2X - paddleWidth + 1;
            }
            if (player2Rec.IntersectsWith(wallRec6))
            {
                paddle2Y = paddle2Y - paddleWidth - 1;
            }
            if (player2Rec.IntersectsWith(wallRec5))
            {
                paddle2X = paddle2X - paddleWidth -1;
            }

            //Set Colison For Ball
            if (ballRec.IntersectsWith(wallRec1))
            {
                ballXSpeed *= -1;
            }

            if (ballRec.IntersectsWith(wallRec2))
            {
                ballXSpeed *= -1;
            }

            if (ballRec.IntersectsWith(wallRec3))
            {
                ballYSpeed *= -1;
            }

            if (ballRec.IntersectsWith(wallRec4))
            {
                ballXSpeed *= -1;
            }

            if (ballRec.IntersectsWith(wallRec5))
            {
                ballXSpeed *= -1;
            }

            if (ballRec.IntersectsWith(wallRec6))
            {
                ballYSpeed *= -1;
            }


            //Who got the point and rest the paddles positions 
            if (ballRec.IntersectsWith(net2))
            {
                airHorn.Play();
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                ballX = 292;
                ballY = 195;
                paddle1X = 110;
                paddle1Y = 180;
                paddle2X = 460;
                paddle2Y = 180;
            }

            

                if (ballRec.IntersectsWith(net1))
            {
                airHorn.Play();
                player2Score ++;
                p2ScoreLabel.Text = $"{player2Score}";
                ballX = 292;
                ballY = 195;
                paddle1X = 110;
                paddle1Y = 180;
                paddle2X = 460;
                paddle2Y = 180;
            }
                //When one player has 3 points end Game 
            if (player1Score == 3 || player2Score == 3)
            {
                timer1.Enabled = false;
            }


            Refresh();
        }
    }
}




