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
using Microsoft.Xna.Framework.Input.Touch;

namespace EmergencyExit
{
    public class MainMenu
    {
        private Texture2D startScreen;
        private Texture2D exitLayer;
        private Texture2D exitLayer2;

        private Vector2 playerPosition;
        private Texture2D playerTexture;

        private Point frameSize;
        private Point currentFrame;
        private Point totalFrames;
        private Vector2 Scale = new Vector2(1.2f,1.2f);
        private float Orientation;
        private Vector2 Velocity;
        private Texture2D fire;
        protected float frameLength = 0.5F;

        private float timer;

        public float Fps
        {
            get { return (int)(1F / frameLength); }
            set { frameLength = (float)Math.Max(1F / (float)value, 0.01F); }
        }

        public MainMenu()
        {
            startScreen = Art.startScreen;
            exitLayer = Art.exitLayer;
            exitLayer2 = Art.exitLayer2;

            playerTexture = Art.playerAnim;
            fire = Art.Fire;
            playerPosition.X = 0-(Art.playerAnim.Width/7) - 100;
            playerPosition.Y = GameRoot.ScreenSize.Y - Art.Floor.Height - Art.playerAnim.Height * Player.Instance.Scale.Y;

            totalFrames = new Point(7, 1);
            frameSize = new Point(200, 223);
            Velocity = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            HandleTouchInput();

            playerPosition += Velocity;


            if((playerPosition.X) > GameRoot.ScreenSize.X)
            {
                GameRoot.gameState = GameRoot.GameState.Playing;
            }

            currentFrame.Y = 0;
            Fps = 12;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= frameLength)
            {
                timer = 0f;
                currentFrame.X = (currentFrame.X + 1) % totalFrames.X;
            }
        }

        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.Position.X >= 1500 && gesture.Position.X <= 1500+238
                    && gesture.Position.Y >= 427 && gesture.Position.Y <= 427+128)
                {
                    Velocity = new Vector2(18, 0);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startScreen, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(fire, new Vector2(0 - Art.Fire.Width / 2, 0), Color.White);
            spriteBatch.Draw(playerTexture, playerPosition, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, Orientation, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(exitLayer, new Vector2(1618, 512), Color.White);
            spriteBatch.Draw(exitLayer2, new Vector2(1721, 511), Color.White);
        }

    }
}