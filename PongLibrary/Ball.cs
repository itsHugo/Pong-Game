using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PongLibrary
{
    public class Ball
    {
        private Vector2 velocity;
        private Rectangle screenDimensions;
        private Rectangle boundingBox;
        private Paddle paddle; 
        public Ball(int ballWidth, int ballHeight,
            int screenWidth, int screenHeight, Vector2 velocity, Paddle paddle)
        {
            this.velocity = velocity;
            this.paddle = paddle;
            screenDimensions.Width = screenWidth;
            screenDimensions.Height = screenHeight;
            boundingBox.Width = ballWidth;
            boundingBox.Height = ballHeight;
            boundingBox.X = (screenWidth - ballWidth) / 2;
            boundingBox.Y = 0;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
        }

        public void Move()
        {
            boundingBox.Y += (int)velocity.Y;
            boundingBox.X += (int)velocity.X;

            this.Bounce();
            //boundingBox.X += (int) (MathHelper.Clamp(boundingBox.X + velocity.X, 0, screenDimensions.X - boundingBox.Width));
            //boundingBox.X += (int)velocity.X;
            //boundingBox.Y += (int)(MathHelper.Clamp(boundingBox.Y + velocity.Y, 0, screenDimensions.Height - boundingBox.Height));
            
            
            
            
            
        }

        public void Bounce()
        {
            if (this.boundingBox.Intersects(paddle.BoundingBox))
                velocity.Y *= -1;


            if (boundingBox.Y >= screenDimensions.Height - boundingBox.Height)
            {
                velocity.Y *= 0;
                velocity.X *= 0;
                // velocity.Y *= -1;
            }

            if (boundingBox.Y <= 0)
            {
                velocity.Y *= -1;
            }

            if (boundingBox.X >= screenDimensions.Width - boundingBox.Width)
                velocity.X *= -1;

            if (boundingBox.X <= 0)
                velocity.X *= -1;

        }



    }
}
