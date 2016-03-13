using System;
using PongLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PongTests
{
    [TestClass]
    public class PaddleTests
    {
        [TestMethod]
        public void MoveLeft_EnoughSpace()
        {
            //arrange
            PongLibrary.Paddle paddle = createPaddle();

            //act
            paddle.MoveLeft();
            int x = paddle.BoundingBox.X;

            //assert
            Assert.AreEqual(2, x); //expected, actual
        }

        [TestMethod]
        public void MoveLeft_PartialSpace()
        {
            //arrange
            Paddle paddle = createPaddle();

            //act
            while (paddle.BoundingBox.X != 0)
                paddle.MoveLeft();
            int x = paddle.BoundingBox.Left;

            //assert
            Assert.AreEqual(0, x);

        }

        [TestMethod]
        public void MoveLeft_NoSpace()
        {
            //arrange
            Paddle paddle = createPaddle();
            
            //act
            while (paddle.BoundingBox.X != 0)
                paddle.MoveLeft();

            paddle.MoveLeft();
            int x = paddle.BoundingBox.Left;

            //assert
            Assert.AreEqual(0, x);
        }

        [TestMethod]
        public void MoveRight_EnoughSpace()
        {
            //arrange
            PongLibrary.Paddle paddle = createPaddle();

            //act
            paddle.MoveRight();
            int x = paddle.BoundingBox.X;

            //assert
            Assert.AreEqual(8, x); //expected, actual
        }

        [TestMethod]
        public void MoveRight_PartialSpace()
        {
            //arrange
            Paddle paddle = createPaddle();

            //act
            while (paddle.BoundingBox.X != 10)
                paddle.MoveRight();
            int x = paddle.BoundingBox.Left;

            //assert
            Assert.AreEqual(10, x);

        }

        [TestMethod]
        public void MoveRight_NoSpace()
        {
            //arrange
            Paddle paddle = createPaddle();

            //act
            while (paddle.BoundingBox.X != 10)
                paddle.MoveRight();

            paddle.MoveRight();
            int x = paddle.BoundingBox.Left;

            //assert
            Assert.AreEqual(10, x);
        }

        private Paddle createPaddle()
        {
            int paddleW = 10;
            int screenW = 20;
            int speed = 3;
            Paddle paddle = new Paddle(paddleW, 0, screenW, 0, speed);

            return paddle;
        }
    }
}
