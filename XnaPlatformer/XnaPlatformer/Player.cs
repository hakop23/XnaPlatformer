using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaPlatformer
{
    public class Player : AnimatedSprite
    {
        public Vector2 speed;
        public Player(Texture2D texture, Vector2 position, Color color, Vector2 speed, List<Rectangle> frames)
            : base(texture, position, color, frames)
        {
            this.speed = speed;
        }
    }
}
