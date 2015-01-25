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
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(resumeButton, new Vector2(805, 418), Color.White);
            spriteBatch.Draw(aboutButton, new Vector2(805, 548), Color.White);
            spriteBatch.Draw(quitButton, new Vector2(805, 688), Color.White);
        }
    }
}