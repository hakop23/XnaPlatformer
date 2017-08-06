using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XnaPlatformer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Brick> bricks;
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 800;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            List<Rectangle> playerFrames = new List<Rectangle>();
            Dictionary<Player.State, Animation> playerAnimations = new Dictionary<Player.State, Animation>();

            //idle
            List<Rectangle> idleFrames = new List<Rectangle>();
            idleFrames.Add(new Rectangle(12, 16, 42, 48));
            idleFrames.Add(new Rectangle(72, 16, 42, 48));
            idleFrames.Add(new Rectangle(140, 16, 40, 48));
            playerAnimations.Add(Player.State.Idle, new Animation(idleFrames, TimeSpan.FromMilliseconds(100), true));

            //running
            List<Rectangle> runningFrames = new List<Rectangle>();
            runningFrames.Add(new Rectangle(202, 20, 48, 44));
            runningFrames.Add(new Rectangle(272, 16, 32, 47));
            runningFrames.Add(new Rectangle(330, 20, 41, 44));

            playerAnimations.Add(Player.State.Running, new Animation(runningFrames, TimeSpan.FromMilliseconds(100), true));

            //jumping
            List<Rectangle> jumpingFrames = new List<Rectangle>();
            jumpingFrames.Add(new Rectangle(390, 8, 52, 56));
            jumpingFrames.Add(new Rectangle(261, 66, 53, 60));
            playerAnimations.Add(Player.State.Air, new Animation(jumpingFrames, TimeSpan.FromMilliseconds(100), false));


            player = new Player(Content.Load<Texture2D>("FightingAndJumpingSpriteSheet"), new Vector2(300, 200), Color.White, 0f, new Vector2(), 1f, new Vector2(5, 0), playerAnimations);
            bricks = new List<Brick>();
            bricks.Add(new Brick(Content.Load<Texture2D>("Bricks"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.White, 0F, Vector2.Zero, 1f));
            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();




            //loop through bricks
            //if player intersects brick, set players ground = bricks Y position

            player.KeyboardInput(ks);
            player.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);


            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(spriteBatch);
            }
            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
