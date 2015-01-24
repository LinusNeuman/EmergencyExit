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
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startScreen, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(exitLayer, new Vector2(1410, 286), Color.White);


        }

    }
}