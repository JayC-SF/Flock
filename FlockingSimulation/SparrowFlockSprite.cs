using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingSimulation
{
    /// <summary>
    /// SparrowFlockSprite holds all the fields and methods to display the flock of sparrows on the Monogame project
    /// </summary>
    public class SparrowFlockSprite : DrawableGameComponent
    {
        /// <summary>
        /// spirteBatch is a SpriteBatch object that will load the Sparrow Icon as a Sprite
        /// </summary>
        private SpriteBatch spriteBatch;
        /// <summary>
        /// sparrowTexture is a Texture2D that represents the icon of the Sparrow
        /// </summary>
        private Texture2D sparrowTexture;
        /// <summary>
        /// game object is an instance of a Game1 object
        /// </summary>
        private Game1 game;
        /// <summary>
        /// sparrows holds a list of all the Sparrow objects inside the project
        /// </summary>
        private List<Sparrow> sparrows;
        /// <summary>
        /// OriginRotationX is a constant value to define the origin of the Sparrow rotation on the X axis
        /// </summary>
        private const int OriginRotationX = 10;
        /// <summary>
        /// OriginRotationY is a constant value to define the origin of the Sparrow rotation on the Y axis
        /// </summary>
        private const int OriginRotationY = 10;

        /// <summary>
        /// Parameterized Constructor for SparrowFlockSprite object to initialize game1 and sparrows objects
        /// </summary>
        /// <param name="game1"></param>
        /// <param name="sparrows"></param>
        public SparrowFlockSprite(Game1 game1, List<Sparrow> sparrows) : base(game1)
        {
            this.game = game1;
            this.sparrows = sparrows;
        }

        /// <summary>
        /// Initialize() initializes the Initialize() from DrawableGameComponent
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent() loads the Sparrow Texture2D object
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sparrowTexture = game.Content.Load<Texture2D>("sparrow");
            base.LoadContent();
        }

        /// <summary>
        /// Update() updates the SparrowFlockSprite at every second of the project running
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw() draws the SparrowFlockSprite onto the project
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Sparrow sparrow in sparrows)
            {
                var position = new Microsoft.Xna.Framework.Vector2(sparrow.Position.Vx, sparrow.Position.Vy);
                var originRotation = new Microsoft.Xna.Framework.Vector2(OriginRotationX, OriginRotationY);
                spriteBatch.Draw(sparrowTexture, position, null, Color.White, sparrow.Rotation, originRotation, 1, SpriteEffects.None, 0f);

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}