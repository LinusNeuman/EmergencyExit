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
    public class Button
    {
        protected Texture2D texture;
        private Vector2 position;

        bool actionTrue;

        private int type;

        public Button(int Type)
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
            type = Type;
        }

        public void Update()
        {
            HandleTouchInput(type);
        }

        private void HandleTouchInput(int type)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if(gesture.Position.X >= position.X && gesture.Position.X <= texture.Width
                    && gesture.Position.Y >= position.Y && gesture.Position.Y <= texture.Height)
                {
                    actionTrue = true;
                }
                actionTrue = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}