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
    public class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 centre;
        private Viewport viewport;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(GameTime gameTime)
        {
            centre = new Vector2(Player.Instance.Position.X + ((Player.Instance.image.Width / Player.Instance.totalFrames.X) / 3) - GameRoot.ScreenSize.X / 3, 0);
            transform = Matrix.CreateScale(new Vector3(1,1,0)) * 
                Matrix.CreateTranslation(new Vector3(-centre.X,-centre.Y,0));
        }
    }
}