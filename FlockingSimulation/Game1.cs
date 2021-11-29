using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlockingBackend;
namespace FlockingSimulation
{
    /// <summary>
    /// Game1 class holds all the fields and methods that dictates the functionality of the Monogame project 
    /// </summary>
    public class Game1 : Game
    {
        /// <summary>
        /// _graphics is a GraphicsDeviceManager object to manage the graphics of Monogame
        /// </summary>
        private GraphicsDeviceManager _graphics;
        /// <summary>
        /// spirteBatch is a SpriteBatch object to handle the project sprites
        /// </summary>
        private SpriteBatch _spriteBatch;
        /// <summary>
        /// sparrowFlockSprite is an instance of the sprite for the Sparrow object
        /// </summary>
        private SparrowFlockSprite sparrowFlockSprite;
        /// <summary>
        /// ravenSprite is an instance of the sprite for the Raven object
        /// </summary>
        private RavenSprite ravenSprite;
        /// <summary>
        /// world is an instance of the World object where the Sparrows and Raven objects interact with each other
        /// </summary>
        private World world;

        /// <summary>
        /// Default constructor for Game1 class
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize() initializes the graphics and sprites of the project
        /// </summary>
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = World.Height;
            _graphics.PreferredBackBufferWidth = World.Width;
            _graphics.ApplyChanges();

            // TODO: Add your initialization logic here
            world = new World();
            sparrowFlockSprite = new SparrowFlockSprite(this, world.Sparrows);
            ravenSprite = new RavenSprite(this, world.Raven);
            Components.Add(sparrowFlockSprite);
            Components.Add(ravenSprite);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent initializes the _spriteBatch of the project
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Update() refreshes the World object and the project at every frame rate
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            world.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw() draws the components and sprites of the project onto the screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
