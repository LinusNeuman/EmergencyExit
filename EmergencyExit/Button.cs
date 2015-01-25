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
        public Texture2D texture;
        private Vector2 position;

        public bool actionTrue;

        private int type;

        public Button(int Type, Texture2D Texture, Vector2 Position)
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
            type = Type;
            texture = Texture;
            position = Position;
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

                if (type == 2)
                {
                    if (gesture.Position.X >= position.X && gesture.Position.X <= 0 + texture.Width + 30
                        && gesture.Position.Y >= position.Y && gesture.Position.Y <= 0 + 30 + Art.pauseButtonUp.Height)
                    {


                        actionTrue = true;

                    }
                }

                if (type == 1)
                {
                    if (gesture.Position.X >= position.X && gesture.Position.X <= 0 + texture.Width + 30
                        && gesture.Position.Y >= position.Y && gesture.Position.Y <= GameRoot.ScreenSize.Y - 30)
                    {

                        actionTrue = true;
                    }
                }

                

            }
            //while (!TouchPanel.IsGestureAvailable)
            //{
            //    actionTrue = false;

            //    return;
            //}

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}