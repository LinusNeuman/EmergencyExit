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

        public MainMenu()
        {
            startScreen = Art.startScreen;
            exitLayer = Art.exitLayer;
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

                if (gesture.Position.X >= 35 && gesture.Position.X <= 35 + 544
                    && gesture.Position.Y >= 517 && gesture.Position.Y <= 517+258)
                {
                    GameRoot.gameState = GameRoot.GameState.Playing;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startScreen, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(exitLayer, new Vector2(1410, 286), Color.White);
        }

    }
}