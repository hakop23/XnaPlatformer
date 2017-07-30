using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaPlatformer
{
    public class Animation
    {
        // later List<Frame> because each frame may need its own origin

        public Rectangle CurrentFrame
        {
            get
            {
                return frames[currentFrame];
            }
        }

        List<Rectangle> frames;
        int currentFrame;
        TimeSpan frameRate;
        TimeSpan timer = TimeSpan.Zero;
        bool repeating;

        public Animation(List<Rectangle> frames, TimeSpan frameRate, bool repeating)
        {
            this.frames = frames;
            this.frameRate = frameRate;
            currentFrame = 0;
            this.repeating = repeating;
        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime;
            if (timer > frameRate)
            {
                currentFrame++;
                if (currentFrame >= frames.Count)
                {
                    if (repeating)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = frames.Count - 1;
                    }
                }
                timer = TimeSpan.Zero;
            }
        }
    }
}
