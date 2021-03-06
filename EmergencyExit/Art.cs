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
        public static Texture2D Floor { get; private set; }
        public static Texture2D jumpButtonUp { get; private set; }
        public static Texture2D pauseButtonUp { get; private set; }
        public static Texture2D jumpButtonPressed { get; private set; }
        public static Texture2D pauseButtonPressed { get; private set; }
        public static Texture2D playerAnim { get; private set; }
        public static Texture2D startScreen { get; private set; }
        public static Texture2D exitLayer { get; private set; }
        public static Texture2D playerAnimJump { get; private set; }
        public static Texture2D exitLayer2 { get; private set; }
        public static Texture2D AboutButton { get; private set; }
        public static Texture2D ResumeButton { get; private set; }
        public static Texture2D QuitButton { get; private set; }
        public static Texture2D PauseMenu { get; private set; }
        public static Texture2D About { get; private set; }
        public static Texture2D GameOver { get; private set; }
        public static Texture2D GameOverButton { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Fire = content.Load<Texture2D>("Fire");
            Background = content.Load<Texture2D>("Background");
            Door = content.Load<Texture2D>("Door");
            Obstacle = content.Load<Texture2D>("Obstacle");
            Floor = content.Load<Texture2D>("Floor");
            jumpButtonUp = content.Load<Texture2D>("jumpButtonUp");
            pauseButtonUp = content.Load<Texture2D>("pauseButtonUp");
            jumpButtonPressed = content.Load<Texture2D>("jumpButtonPressed");
            pauseButtonPressed = content.Load<Texture2D>("pauseButtonPressed");
            playerAnim = content.Load<Texture2D>("PlayerAnim");
            startScreen = content.Load<Texture2D>("Startscreen");
            exitLayer = content.Load<Texture2D>("ExitLayer");
            playerAnimJump = content.Load<Texture2D>("PlayerAnimJump");
            exitLayer2 = content.Load<Texture2D>("GreenExitLayer");
            AboutButton = content.Load<Texture2D>("AboutButton");
            ResumeButton = content.Load<Texture2D>("ResumeButton");
            QuitButton = content.Load<Texture2D>("QuitButton");
            PauseMenu = content.Load<Texture2D>("PauseMenu");
            About = content.Load<Texture2D>("About");
            GameOver = content.Load<Texture2D>("GameOver");
            GameOverButton = content.Load<Texture2D>("GameOverButton");
        }
    }
}