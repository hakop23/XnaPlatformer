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
        Brick brick;
        List<Brick> bricks;
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

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

            //idle
            playerFrames.Add(new Rectangle(12, 16, 42, 48));
            //playerFrames.Add(new Rectangle(72, 16, 42, 48));
            //playerFrames.Add(new Rectangle(140, 16, 40, 48));

            //running
            playerFrames.Add(new Rectangle(202, 20, 48, 44));
            playerFrames.Add(new Rectangle(272, 16, 32, 47));
            playerFrames.Add(new Rectangle(330, 20, 41, 44));

            //jumping
            playerFrames.Add(new Rectangle(390, 8, 52, 56));
            playerFrames.Add(new Rectangle(261, 66, 53, 60));

            brick = new Brick(Content.Load<Texture2D>("Bricks"), new Vector2(80, 80), Color.White, 0F, new Vector2(), 1f);
            player = new Player(Content.Load<Texture2D>("FightingAndJumpingSpriteSheet"), new Vector2(50, 80), Color.White, 0f, new Vector2(), 1f, new Vector2(0, 0), playerFrames);
            bricks = new List<Brick>();
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(spriteBatch);
            }
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

            brick.Draw(spriteBatch);
            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
