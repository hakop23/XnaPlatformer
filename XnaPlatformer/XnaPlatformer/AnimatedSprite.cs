using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaPlatformer
{
    public class AnimatedSprite : Sprite
    {

        List<Rectangle> frames;
        int currentFrame;

        public AnimatedSprite(Texture2D texture, Vector2 position, Color color, List<Rectangle> frames)
            : base(texture, position, color)
        {
            this.frames = frames;
            currentFrame = 0;            
        }



        public override void Update(GameTime gameTime)
        {
           //animating
          
            
            base.Update(gameTime);
        }
    }
}
