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

namespace EmergencyExit
{
    public class ButtonManager
    {
        public Button jumpButton;
        public Button pauseButton;

        public static ButtonManager instance;

        public ButtonManager()
        {
            jumpButton = new Button(1, Art.jumpButtonUp, new Vector2(0 + 30, GameRoot.ScreenSize.Y - Art.jumpButtonUp.Height - 30));
            pauseButton = new Button(2, Art.pauseButtonUp, new Vector2(0 + 60,0 + 60));

            instance = this;
        }

        public void Update()
        {
            if (jumpButton.actionTrue == true)
            {
                jumpButton.texture = Art.jumpButtonPressed;
            }
            if (jumpButton.actionTrue == false)
            {
                jumpButton.texture = Art.jumpButtonUp;
            }
            if (pauseButton.actionTrue == true)
            {
                pauseButton.texture = Art.pauseButtonPressed;
            }
            if (pauseButton.actionTrue == false)
            {
                pauseButton.texture = Art.pauseButtonUp;
            }

            jumpButton.Update();
            pauseButton.Update();

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            jumpButton.Draw(spriteBatch);
            pauseButton.Draw(spriteBatch);
        }
    }
}