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
    class Player : Entity
    {
        private Vector2 Direction;

        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();

                return instance;
            }
        }

        ButtonManager btnMgr;

        private Player()
        {
            image = Art.Player;
            Position = GameRoot.ScreenSize / 5;

            btnMgr = new ButtonManager();
        }

        public override void Update()
        {
            const float speed = 16;
            Direction = new Vector2(1, 0);

            Velocity = speed * Direction;
            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);
        }


        public void Jump()
        {
            
        }
    }
}