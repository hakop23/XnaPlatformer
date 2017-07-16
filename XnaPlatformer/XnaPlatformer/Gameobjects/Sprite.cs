using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaPlatformer.Gameobjects
{
     class Sprite
    {
        protected Vector2 position;
        protected Color color;
        protected Texture2D texture;
        protected Rectangle hitbox;
        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            this.position = position;
            this.texture = texture;
            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            this.color = color;
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, color);
        } 
        public virtual void Update()
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}
