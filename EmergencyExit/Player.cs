using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmergencyExit
{
    class Player : Entity
    {
        private float jumpTimer;

        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();

                return instance;
            }
        }

        ButtonManager btnMgr;

        private Player()
        {
            image = Art.playerAnim;

            Scale = new Vector2(1.2f, 1.2f);

            Position.X = GameRoot.ScreenSize.X / 5;
            Position.Y = GameRoot.ScreenSize.Y - Art.Floor.Height -  Art.playerAnim.Height * Scale.Y;

            frameSize = new Point(200, 232);
            totalFrames = new Point(8, 1);
            

            btnMgr = new ButtonManager();
        }

        public Rectangle Hitbox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (frameSize.X), (frameSize.Y));
        }

        public override void Update(GameTime gameTime)
        {
            btnMgr.Update();


            const float speed = 16;
            Direction = new Vector2(0, 0);

            Velocity = speed * Direction;
            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);

            //if (Hitbox().Intersects(

            jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (btnMgr.jumpButton.actionTrue == true)
            {
                if (jumpTimer >= 1)
                {
                    Jump();
                    jumpTimer = 0;
                }
            }


            currentFrame.Y = 0;
            Fps = 5;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer >= frameLength)
            {
                timer = 0f;
                currentFrame.X = (currentFrame.X + 1) % totalFrames.X;
            }

        }

        public void Jump()
        {
            Direction.Y = 1;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, Orientation, Vector2.Zero, Scale, SpriteEffects.None, 0);
            //base.Draw(spriteBatch);
        }
    }
}