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
    public class ButtonManager
    {
        public Button jumpButton;
        public Button pauseButton;

        private float timer1, timer2;

        public static ButtonManager instance;

        public ButtonManager()
        {
            jumpButton = new Button(1, Art.jumpButtonUp, new Vector2(0 + 30, GameRoot.ScreenSize.Y - Art.jumpButtonUp.Height - 30));
            pauseButton = new Button(3, Art.pauseButtonUp, new Vector2(0 + 30,0 + 30));

            instance = this;
        }

        public void Update(GameTime gameTime)
        {

            jumpButton.Update();
            pauseButton.Update();

            timer1 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            timer2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (jumpButton.actionTrue == true && Player.Instance.isOnGround == true)
            {
                timer1 = 0;
                jumpButton.texture = Art.jumpButtonPressed;
                Player.Instance.Jump();
            }
            if (jumpButton.actionTrue == false)
            {
                if (timer1 >= 100)
                {
                    jumpButton.texture = Art.jumpButtonUp;
                }
            }
            if (pauseButton.actionTrue == true)
            {
                timer2 = 0;
                pauseButton.texture = Art.pauseButtonPressed;
                GameRoot.gameState = GameRoot.GameState.PauseMenu;
            }
            if (pauseButton.actionTrue == false)
            {
                if (timer2 >= 100)
                {
                    pauseButton.texture = Art.pauseButtonUp;
                }
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            jumpButton.Draw(spriteBatch);
            pauseButton.Draw(spriteBatch);
        }
    }
}