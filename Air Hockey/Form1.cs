using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        int playerTurn = 1;
        int paddle1X = 50;
        int paddle1Y = 250;
        int player1Score = 0;

        int paddle2X = 500;
        int paddle2Y = 250;
        int player2Score = 0;

        int paddleWidth = 40;
        int paddleHeight = 40;
        int paddleSpeed = 4;

        int ballX = 290;
        int ballY = 264;
        int ballXSpeed = 6;
        int ballYSpeed = 6;
        int ballWidth = 15;
        int ballHeight = 15;


        bool rightDown = false;
        bool leftDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool wDown = false;
        bool sDown = false;

        SolidBrush rBrush = new SolidBrush(Color.Firebrick);
        SolidBrush gMoving = new SolidBrush(Color.DarkGreen);
        SolidBrush bMoving = new SolidBrush(Color.DarkBlue);
        Pen highLight = new Pen(Color.White);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(rBrush, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.FillEllipse(bMoving, paddle1X, paddle1Y, paddleWidth, paddleHeight);

            e.Graphics.FillEllipse(gMoving, paddle2X, paddle2Y, paddleWidth, paddleHeight);
        }
        private void upKeys(object sender, KeyEventArgs e)
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

        private void downKeys(object sender, KeyEventArgs e)
        {
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

        private void timer(object sender, EventArgs e)
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

            //if (ballY < 0 || ballY > this.Height - ballHeight)
            //{
            //    ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            //}

            ////create Rectanglesof objectson screento beusedforcollision detection

            ////Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            ////Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            //Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);

            ////check if ball hits either paddle. If it does change the direction 
            ////and place the ball in front of the paddle hit 
            //if (playerTurn == 1)
            //{

            //    Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            //    if (player1Rec.IntersectsWith(ballRec))
            //    {

            //        playerTurn++;
            //        ballXSpeed *= -1;
            //        ballX = paddle1X + paddleWidth + 1;
            //    }
            //}
            //if (playerTurn == 2)
            //{

            //    Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            //    if (player2Rec.IntersectsWith(ballRec))
            //    {

            //        playerTurn--;
            //        ballXSpeed *= -1;
            //        ballX = paddle2X + paddleWidth + 1;
            //    }
            //}
            //if (ballX > 600)
            //{
            //    ballXSpeed *= -1;
            //    ballX = ballX - ballWidth + 1;
            //}


            //    //check if either player scores a point 
            //    if (playerTurn == 1 && ballX < 0)
            //    {
            //        player2Score++;
            //        ballX = 300;
            //        ballY = 250;
            //        paddle1X = 0;
            //        paddle1Y = 150;
            //        paddle2X = 0;
            //        paddle2Y = 300;
            //        p2ScoreLabel.Text = $"{player2Score}";


            //    }
            //    //if (playerTurn == 2 && ballX < 0)
            //    {
            //        player1Score++;
            //        ballX = 300;
            //        ballY = 250;
            //        paddle1X = 0;
            //        paddle1Y = 150;
            //        paddle2X = 0;
            //        paddle2Y = 300;

            //        p1ScoreLabel.Text = $"{player1Score}";
            //    }

            //    Refresh();

            //    //check if either player won     

            //    if (player1Score == 3 || player2Score == 3)
            //    {
            //        timer1.Enabled = false;
            //    }

            //    Refresh();
            //}


        }
    }
}
