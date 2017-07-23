using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaPlatformer
{
     public class Sprite
    {
        protected Vector2 position;
        protected Color color;
        protected Texture2D texture;        
        protected Rectangle sourceRectangle;

        public Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            this.position = position;
            this.texture = texture;            
            this.color = color;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            //do the complex add sourceRectangle
             spritebatch.Draw(texture, position, color);
        } 

        public virtual void Update(GameTime gameTime)
        {            
        }
    }
}
