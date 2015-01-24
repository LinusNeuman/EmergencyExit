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

namespace EmergencyExit
{
    public class ButtonManager
    {
        public Button jumpButton;
        public Button pauseButton;

        public static ButtonManager instance;

        public ButtonManager()
        {
            jumpButton = new Button(1);
            pauseButton = new Button(2);

            instance = this;
        }

        public void Update()
        {
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