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
    class Obstacle : Entity
    {
        public Obstacle(Texture2D _texture, Vector2 position,
            Vector2 velocity, float angle, float angularVelocity, Vector2 size, float lifetime)
        {
            image = _texture;
            Scale = size;
            Velocity = velocity;
            Position = position;
        }

        private static Obstacle instance;
        public static Obstacle Instance
        {
            get
            {
                if (instance == null)
                    instance = new Obstacle(Art.Obstacle, new Vector2(GameRoot.ScreenSize.X + Art.Obstacle.Width, GameRoot.ScreenSize.Y - Art.Floor.Height - Art.Obstacle.Height), new Vector2(-6,0), 0f, 0, new Vector2(1f,1f), 50);

                return instance;
            }
        }

        public Rectangle Hitbox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, image.Width, image.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;

            if (Position.X <= 0 + image.Width)
            {
                IsExpired = true;
            }

            if(Hitbox().Intersects(Player.Instance.Hitbox()))
            {
                Player.Instance.Position.X -= 3;
            }
        }
    }
}