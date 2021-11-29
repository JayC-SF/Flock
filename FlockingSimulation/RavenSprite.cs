using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlockingBackend;

namespace FlockingSimulation
{
    /// <summary>
    /// RavenSprite holds all the fields and methods to display the RavenSprite on the Monogame project
    /// </summary>
    public class RavenSprite : DrawableGameComponent
    {
        /// <summary>
        /// game object is an instance of a Game1 object
        /// </summary>
        private Game1 game;
        /// <summary>
        /// spirteBatch is a SpriteBatch object that will load the Raven Icon as a Sprite
        /// </summary>
        private SpriteBatch spriteBatch;
        /// <summary>
        /// ravenTexture is a Texture2D that represents the icon of the Raven
        /// </summary>
        private Texture2D ravenTexture;
        /// <summary>
        /// raven holds the functionality of an instace of a Raven object
        /// </summary>
        private Raven raven;
        /// <summary>
        /// OriginRotationX is a constant value to define the origin of the Raven rotation on the X axis
        /// </summary>
        private const int OriginRotationX = 10;
        /// <summary>
        /// OriginRotationY is a constant value to define the origin of the Raven rotation on the Y axis
        /// </summary>
        private const int OriginRotationY = 10;

        /// <summary>
        /// Parameterized constructor for RavenSprite object to initialize game and raven objects
        /// </summary>
        /// <param name="game"></param>
        /// <param name="raven"></param>
        public RavenSprite(Game1 game, Raven raven) : base(game)
        {
            this.game = game;
            this.raven = raven;
        }

        /// <summary>
        /// Initialize() initializes the Initialize() from DrawableGameComponent
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent() loads the Raven Texture2D object
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ravenTexture = game.Content.Load<Texture2D>("raven");
            base.LoadContent();
        }

        /// <summary>
        /// Update() updates the RavenSprite at every second of the project running
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw() draws the Raven Sprite onto the project
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            var position = new Microsoft.Xna.Framework.Vector2(raven.Position.Vx, raven.Position.Vy);
            var originRotation = new Microsoft.Xna.Framework.Vector2(OriginRotationX, OriginRotationY);
            spriteBatch.Draw(ravenTexture, position, null, Color.White, raven.Rotation, originRotation, 1, SpriteEffects.None, 0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}