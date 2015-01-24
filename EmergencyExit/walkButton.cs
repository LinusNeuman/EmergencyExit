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
    public class walkButton : Button
    {
        public Vector2 direction;

        public walkButton()
        {
            texture = Art.walkButton;
        }
    }
}