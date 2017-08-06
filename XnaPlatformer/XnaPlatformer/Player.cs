using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        State animationState;

        Dictionary<State, Animation> animations;

        float ground = float.MaxValue; //when you intersect with a brick, set ground = that bricks y position
        bool inAir = true;

        //smaller numbers = slower jump, bigger numbers = faster jump
        //bigger DIFFERENCE = higher the jump
        float gravity = 1;
        float jumpPower = 20f;


        public Player(Texture2D texture, Vector2 position, Color color, float rotation, Vector2 origin, float scale, Vector2 speed, Dictionary<State, Animation> animations)
             : base(texture, position, color, rotation, origin, scale)
        {
            this.speed = speed;
            this.animations = animations;
            animationState = State.Idle;
        }


        public override void Update(GameTime gameTime)
        {

            animations[animationState].Update(gameTime);
            sourceRectangle = animations[animationState].CurrentFrame;

            if (inAir)
            {
                //fall
                position.Y += speed.Y;
                speed.Y += gravity;

                if (position.Y >= ground)
                {
                    position.Y = ground;
                    animationState = State.Idle;
                    inAir = false;
                }
            }

            base.Update(gameTime);
        }

        public void KeyboardInput(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.A))
            {
                position.X -= speed.X;
                if (!inAir) animationState = State.Running;
                effect = SpriteEffects.FlipHorizontally;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                position.X += speed.X;
                if (!inAir) animationState = State.Running;
                effect = SpriteEffects.None;
            }
            if (ks.IsKeyDown(Keys.Space) && !inAir) //only on keydown
            {
                //give us a force upward
                speed.Y = -jumpPower;
                inAir = true;
                animationState = State.Air;
            }
            else if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && animationState != State.Air)
            {
                animationState = State.Idle;
            }
        }

    }
}
