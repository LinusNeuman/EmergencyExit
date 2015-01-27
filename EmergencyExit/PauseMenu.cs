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
    public class PauseMenu
    {
        Texture2D background;
        Texture2D resumeButton;
        Texture2D aboutButton;
        Texture2D quitButton;



        public PauseMenu()
        {
            background = Art.PauseMenu;
            resumeButton = Art.ResumeButton;
            aboutButton = Art.AboutButton;
            quitButton = Art.QuitButton;
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
                    GameRoot.gameState = GameRoot.GameState.Playing;
                }
                if (gesture.Position.X >= 805 && gesture.Position.X <= 805 + 311
                    && gesture.Position.Y >= 548 && gesture.Position.Y <= 548 + 92)
                {
                    GameRoot.gameState = GameRoot.GameState.About;
                }
                //if (gesture.Position.X >= 805 && gesture.Position.X <= 805 + 311
                //    && gesture.Position.Y >= 688 && gesture.Position.Y <= 688 + 92)
                //{
                    
                //}
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(resumeButton, new Vector2(805, 418), Color.White);
            spriteBatch.Draw(aboutButton, new Vector2(805, 548), Color.White);
            //spriteBatch.Draw(quitButton, new Vector2(805, 688), Color.White);
        }
    }
}