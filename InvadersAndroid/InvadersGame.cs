using System;
using Infrastructure.Managers;
using Infrastructure.ServiceInterfaces;
using Invaders.Infrastructure;
using Invaders.LocalManagers;
using Invaders.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InvadersAndroid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

    public class InvadersGame : BaseGame
    {
        private const string k_SoundBackgroundName = "BGMusic";
        private ISoundManager m_SoundManager;

        public InvadersGame()
        {
            this.m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IInputManager inputManager = new InputManager(this);
            IPlayersManager livesManager = new PlayersManager(this);
            ICollisionsManager collisionsManager = new CollisionsManager(this);
            IScreensManager screensManager = new ScreensManager(this);
            m_SoundManager = new LocalSoundManager(this);
            IGameSettingsManager IGameSettingsManager = new GameSettingsManager(this);
            screensManager.SetCurrentScreen(new WelcomeScreen(this));

            this.m_Graphics.IsFullScreen = true;
            this.m_Graphics.PreferredBackBufferWidth = 800;
            this.m_Graphics.PreferredBackBufferHeight = 480;
            this.m_Graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);
            this.Services.AddService(typeof(SpriteBatch), this.SpriteBatch);
            this.IsMouseVisible = true;
            m_SoundManager.PlayContinuousSound(k_SoundBackgroundName, true);
            base.Initialize();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
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
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public override void ExitGame()
        {
            this.Exit();
        }
    }
}
