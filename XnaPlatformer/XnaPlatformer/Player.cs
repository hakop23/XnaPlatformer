using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaPlatformer
{
    public class Player : Sprite
    {
        public enum State
        {
            Idle,
            Running,
            Air
        }

        public Vector2 speed;

        State currentState;
        Dictionary<State, Animation> animations;


        public Player(Texture2D texture, Vector2 position, Color color, float rotation, Vector2 origin, float scale, Vector2 speed, Dictionary<State, Animation> animations)
             : base(texture, position, color, rotation, origin, scale)
        {
            this.speed = speed;
            this.animations = animations;
            currentState = State.Idle;
        }


        public override void Update(GameTime gameTime)
        {
            if (currentState == State.Idle)
            {
                animations[currentState];
            }


            base.Update(gameTime);
        }

    }
}
