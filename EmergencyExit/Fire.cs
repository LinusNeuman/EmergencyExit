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
    class Fire : Entity
    {


        private static Fire instance;
        public static Fire Instance
        {
            get
            {
                if (instance == null)
                    instance = new Fire();

                return instance;
            }
        }

        private Fire()
        {
            image = Art.Fire;

            Scale = new Vector2(1, 1);

            Position.X = 0 - Art.Fire.Width / 2; //* Scale.X;
            Position.Y = 0;
        }

        public override void Update(GameTime gameTime)
        {
            const float speed = 16;
            Direction = new Vector2(0, 0);

            Velocity = speed * Direction;
            Position += Velocity;
        }

    }
}