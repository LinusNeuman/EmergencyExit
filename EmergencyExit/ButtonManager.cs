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
        public walkButton WalkButton;
        public Button jumpButton;
        public Button pauseButton;

        public static ButtonManager instance;

        public ButtonManager()
        {
            WalkButton = new walkButton();
            jumpButton = new Button();
            pauseButton = new Button();

            instance = this;
        }

        public void Update()
        {
            WalkButton.Update();
            jumpButton.Update();
            pauseButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            WalkButton.Draw(spriteBatch);
            jumpButton.Draw(spriteBatch);
            pauseButton.Draw(spriteBatch);
        }
    }
}