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
    static class EntityManager
    {
        static public List<Entity> entities = new List<Entity>();

        static bool isUpdating;
        static public List<Entity> addedEntities = new List<Entity>();

        public static int Count { get { return entities.Count; } }

        public static void Add(Entity entity)
        {
            if (!isUpdating)
                entities.Add(entity);
            else
                addedEntities.Add(entity);
        }

        public static void Update(GameTime gameTime)
        {
            isUpdating = true;

            foreach (var entity in entities)
                entity.Update(gameTime);

            isUpdating = false;

            foreach (var entity in addedEntities)
                entities.Add(entity);

            addedEntities.Clear();

            // remove the expired entities
            entities = entities.Where(x => !x.IsExpired).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
                entity.Draw(spriteBatch);
        }
    }
}