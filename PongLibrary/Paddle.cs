using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PongLibrary
{
    public class Paddle
    {
        private readonly int speed;
        private int screenWidth;
        private Rectangle boundingBox;

        public Paddle(int paddleWidth, int paddleHeight,
            int screenWidth, int screenHeight, int speed)
        {
            this.speed = speed;
            this.screenWidth = screenWidth;
            boundingBox.Width = paddleWidth;
            boundingBox.Height = paddleHeight;
            boundingBox.X = (screenWidth - paddleWidth) / 2;
            boundingBox.Y = screenHeight - paddleHeight;
        }

        public Rectangle BoundingBox { 
            get
            {
                return boundingBox;
            }
        }

        public void MoveLeft()
        {         
            boundingBox.X = MathHelper.Clamp(boundingBox.X - speed, 0, screenWidth - boundingBox.Width);
        } 

        public void MoveRight()
        {
            boundingBox.X = MathHelper.Clamp(boundingBox.X + speed, 0, screenWidth - boundingBox.Width);
        } 
    }
}
