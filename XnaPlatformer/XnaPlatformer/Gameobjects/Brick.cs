using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaPlatformer
{
    public class Brick : Sprite
    {
        public Brick(Texture2D texture, Vector2 position, Color color, float rotation, Vector2 origin, float scale) 
            : base(texture, position, color, rotation, origin, scale)
        {

        }
    }
}
