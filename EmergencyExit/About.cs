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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace EmergencyExit
{
    public class About
    {
        Texture2D background;
        Texture2D resumeBtn;


        public About()
        {
            background = Art.About;
            resumeBtn = Art.ResumeButton;
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
                    && gesture.Position.Y >= 768 && gesture.Position.Y <= 768 + 92)
                {
                    GameRoot.gameState = GameRoot.GameState.PauseMenu;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(resumeBtn, new Vector2(805,768), Color.White);
        }
    }
}