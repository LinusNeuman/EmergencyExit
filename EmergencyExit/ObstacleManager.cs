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

namespace EmergencyExit
{
    public class ObstacleManager
    {
        Random r = new Random();
        public float timer;
        int Thevalue;
        public ObstacleManager()
        {
            Thevalue = r.Next(1, 5);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timer >= Thevalue)
            {
                timer = 0;
                EntityManager.Add(new Obstacle(Art.Obstacle, new Vector2(GameRoot.ScreenSize.X + Art.Obstacle.Width, GameRoot.ScreenSize.Y - Art.Floor.Height - Art.Obstacle.Height), new Vector2(-5,0), 0f, 0, new Vector2(1f,1f), 50));
                Thevalue = r.Next(2, 5);
            }
        }

        public void Draw()
        {
            
        }
    }
}