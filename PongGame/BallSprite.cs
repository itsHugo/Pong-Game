using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class BallSprite : DrawableGameComponent
    {
        private Paddle paddle;
        private PaddleSprite paddleSprite;//the business logic
        private Ball ball;
        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imageBall;
        private Game1 game;

        public BallSprite(Game1 game, PaddleSprite paddleSprite)
            : base(game)
        {
            this.game = game;
            this.paddleSprite = paddleSprite;
        }

        public override void Initialize()
        {
            //oldState = Keyboard.GetState();
            //threshold = 6;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imageBall = game.Content.Load<Texture2D>("ball");
            paddle = paddleSprite.Paddle;
            ball =
                new Ball(imageBall.Width, imageBall.Height,
                    GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, new Vector2(2, 2), paddle);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            moveBall();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imageBall, new Vector2(ball.BoundingBox.X,
                ball.BoundingBox.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void initPaddle(PaddleSprite paddleSprite)
        {
            this.paddleSprite = paddleSprite;
            this.paddle = paddleSprite.Paddle;

        }
        private void moveBall()
        {
            ball.Move();
        }

    }
}
