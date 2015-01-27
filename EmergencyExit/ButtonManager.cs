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
using Microsoft.Xna.Framework.Input.Touch;

namespace EmergencyExit
{
    public class ButtonManager
    {
        public jumpButton jumpButton;
        public pauseButton pauseButton;

        private float timer1, timer2;

        public static ButtonManager instance;

        public ButtonManager()
        {
            jumpButton = new jumpButton();
            pauseButton = new pauseButton();

            instance = this;
        }

        public void Update(GameTime gameTime)
        {


            //jumpButton.Update(gameTime);
            //pauseButton.Update(gameTime);

            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.Position.X >= jumpButton.position.X && gesture.Position.X <= 0 + jumpButton.texture.Width + 30
                    && gesture.Position.Y >= jumpButton.position.Y && gesture.Position.Y <= GameRoot.ScreenSize.Y - 30)
                {

                    jumpButton.actionjumpTrue = true;
                }
                if (gesture.Position.X >= pauseButton.position.X && gesture.Position.X <= 0 + pauseButton.texture.Width + 30
                    && gesture.Position.Y >= pauseButton.position.Y && gesture.Position.Y <= GameRoot.ScreenSize.Y - 30)
                {

                    pauseButton.actionpauseTrue = true;
                }



            }
            

            timer1 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (jumpButton.actionjumpTrue == true && Player.Instance.isOnGround == true)
            {
                timer1 = 0;
                jumpButton.texture = Art.jumpButtonPressed;
                Player.Instance.Jump();
                jumpButton.actionjumpTrue = false;
            }
            if (jumpButton.actionjumpTrue == false)
            {
                if (timer1 >= 100)
                {
                    jumpButton.texture = Art.jumpButtonUp;
                }
            }
            if (pauseButton.actionpauseTrue == true)
            {
                pauseButton.texture = Art.pauseButtonPressed;
                GameRoot.gameState = GameRoot.GameState.PauseMenu;
                pauseButton.actionpauseTrue = false;
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            jumpButton.Draw(spriteBatch);
            pauseButton.Draw(spriteBatch);
        }
    }
}