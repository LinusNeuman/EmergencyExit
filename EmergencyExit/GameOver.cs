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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace EmergencyExit
{
    public class GameOver
    {
        Texture2D background;
        Texture2D retryButton;

        public GameOver()
        {
            background = Art.GameOver;
            retryButton = Art.GameOverButton;
        }

        public void Update()
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.Position.X >= 805 && gesture.Position.X <= 805 + 311
                    && gesture.Position.Y >= 418 && gesture.Position.Y <= 418 + 92)
                {
                    GameRoot.ResetGame();
                    GameRoot.gameState = GameRoot.GameState.Playing;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(retryButton, new Vector2(805,418), Color.White);
        }
    }
}