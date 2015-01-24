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
    public class Floor
    {
        Texture2D texture;
        Vector2 Position;


        public Floor()
        {
            texture = Art.Floor;
            Position = new Vector2(0, GameRoot.ScreenSize.Y - Art.Floor.Height);
        }

        public Rectangle Hitbox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public void Update()
        {
            if(Hitbox().Intersects(Player.Instance.Hitbox()))
            {
                Player.Instance.Velocity.Y = 0f;
                Player.Instance.canJump = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}