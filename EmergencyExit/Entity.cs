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
    abstract class Entity
    {
        protected Vector2 Direction;

        public Texture2D image;

        protected Color color = Color.White;

        public Vector2 Position, Velocity;
        public float Orientation;
        public float Radius = 20; // Circle collision (we need squares..)
        public bool IsExpired;

        public Point currentFrame; // This is a class made for objects that will move, and gives it some variables to do so, like speed, direction and angle. - Linus
        public Point frameSize;
        public Point totalFrames;
        protected float frameLength = 0.5F;
        protected float timer = 0;

        public Vector2 Scale;

        public Vector2 Size
        {
            get
            {
                return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height);
            }
        }

        public float Fps
        {
            get { return (int)(1F / frameLength); }
            set { frameLength = (float)Math.Max(1F / (float)value, 0.01F); }
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, color, Orientation, Vector2.Zero, Scale, 0, 0);
        }
    }
}