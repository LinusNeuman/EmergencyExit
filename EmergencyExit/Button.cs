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
    public class pauseButton
    {
        public Texture2D texture;
        public Vector2 position;

        public bool actionpauseTrue;


        public pauseButton()
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
            texture = Art.pauseButtonUp;
            position = new Vector2(0 + 30, 0 + 30);
        }

        public void Update(GameTime gameTime)
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.Position.X >= position.X && gesture.Position.X <= 0 + texture.Width + 30
                    && gesture.Position.Y >= position.Y && gesture.Position.Y <= 0 + 30 + Art.pauseButtonUp.Height)
                {


                    actionpauseTrue = true;

                }



            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}