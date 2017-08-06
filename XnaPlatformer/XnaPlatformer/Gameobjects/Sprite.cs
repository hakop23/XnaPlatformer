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
        protected float rotation;
        protected Vector2 origin;
        protected float scale;
        protected SpriteEffects effect;
        public Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height); }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color, float rotation, Vector2 origin, float scale)
        {
            this.position = position;
            this.texture = texture;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effect = SpriteEffects.None;
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            //do the complex add sourceRectangle
            spritebatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effect, 1f);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
