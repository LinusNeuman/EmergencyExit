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
using Microsoft.Xna.Framework.Content;

namespace EmergencyExit
{
    static class Art
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D Fire { get; private set; }
        public static Texture2D Background { get; private set; }
        public static Texture2D Door { get; private set; }
        public static Texture2D Obstacle { get; private set; }
        public static Texture2D FloorAndWall { get; private set; }
        public static Texture2D walkButton { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Fire = content.Load<Texture2D>("Fire");
            Background = content.Load<Texture2D>("Background");
            Door = content.Load<Texture2D>("Door");
            Obstacle = content.Load<Texture2D>("Obstacle");
            walkButton = content.Load<Texture2D>("walkButton");

        }
    }
}