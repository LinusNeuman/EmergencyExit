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

        public MainMenu()
        {
            startScreen = Art.startScreen;
            exitLayer = Art.exitLayer;
            exitLayer2 = Art.exitLayer2;
        }

        public void Update(GameTime gameTime)
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.Position.X >= 1500 && gesture.Position.X <= 1500+238
                    && gesture.Position.Y >= 427 && gesture.Position.Y <= 427+128)
                {
                    GameRoot.gameState = GameRoot.GameState.Playing;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startScreen, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(exitLayer, new Vector2(1618, 512), Color.White);
            spriteBatch.Draw(exitLayer2, new Vector2(1721, 511), Color.White);
        }

    }
}