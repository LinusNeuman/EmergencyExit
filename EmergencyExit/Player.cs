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
        public bool isJumping;
        public bool canJump;

        public bool isOnGround;

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
            Position.Y = GameRoot.ScreenSize.Y - Art.Floor.Height -  Art.playerAnim.Height * Scale.Y - 87;

            //frameSize = new Point(((int)(200 * Scale.X)), ((int)(223 * Scale.Y)));
            totalFrames = new Point(8, 1);
            Direction = new Vector2(1, 0);
            Velocity = new Vector2(5, 0);


            btnMgr = new ButtonManager();
        }

        public Rectangle Hitbox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)(frameSize.X * (Scale.X)), (int)(frameSize.Y * Scale.Y));
        }

        public override void Update(GameTime gameTime)
        {
            btnMgr.Update(gameTime);

            if(isJumping)
            {
                image = Art.playerAnimJump;
                totalFrames = new Point(8,1);
                frameSize = new Point(1, 1);
                Scale = new Vector2(2.21f, 2.21f);
            }
            if(isOnGround)
            {
                image = Art.playerAnim;
                totalFrames = new Point(7, 1);
                frameSize = new Point(200,223);
                Scale = new Vector2(1.2f, 1.2f);
            }
            
            const float speed = 8;

            Position += Velocity;
            //Position = Vector2.Clamp(Position, (new Vector2(0,0) - (Size / 9)) / 2, GameRoot.ScreenSize - (Size / 9));

            //if (Hitbox().Intersects(

            if(Velocity.Y < 10)
            {
                Velocity.Y += 0.6f;
            }

            jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (btnMgr.jumpButton.actionTrue == true && canJump == true)
            {
                if (jumpTimer >= 1)
                {
                    Jump();
                    jumpTimer = 0;
                }
                canJump = false;
                btnMgr.jumpButton.actionTrue = false;
            }


            currentFrame.Y = 0;
            Fps = 12;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer >= frameLength)
            {
                timer = 0f;
                currentFrame.X = (currentFrame.X + 1) % totalFrames.X;
            }

        }

        public void Jump()
        {
            Position.Y -= 10f;
            Velocity.Y = -16f;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, Orientation, Vector2.Zero, Scale, SpriteEffects.None, 0);
            //base.Draw(spriteBatch);
        }
    }
}