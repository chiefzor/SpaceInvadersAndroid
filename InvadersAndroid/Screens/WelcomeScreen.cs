using Infrastructure.ObjectModel;
using Infrastructure.ObjectModel.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Invaders.Infrastructure;
using Invaders.ObjectModel;
using Microsoft.Xna.Framework.Input.Touch;

namespace Invaders.Screens
{
    public class WelcomeScreen : GameScreen
    {
        private GameText2D m_WelcomeMessage;
        private GameText2D m_EnterToplay;
        private GameText2D m_HToMainMenu;
        private GameText2D m_EscToExit;

        private BaseGame m_Game;

        public WelcomeScreen(BaseGame i_Game)
            : base(i_Game)
        {
            m_Game = i_Game;

            Background background = new Background(i_Game, this, 1);

            m_WelcomeMessage = new GameText2D(i_Game, this, @"Fonts\Showcard Gothic");

            m_EnterToplay = new GameText2D(i_Game, this, @"Fonts\Jokerman");
            m_HToMainMenu = new GameText2D(i_Game, this, @"Fonts\Jokerman");
            m_EscToExit = new GameText2D(i_Game, this, @"Fonts\Jokerman");

            this.UseFadeTransition = false;

            this.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.NonPremultiplied;
        }

        public override void Initialize()
        {
            base.Initialize();

            m_WelcomeMessage.Text = "Realm Invaders";
            m_WelcomeMessage.Position = new Vector2(CenterOfViewPort.X - (m_WelcomeMessage.Width / 2), 150);
            m_WelcomeMessage.TintColor = Color.Aquamarine;

            m_EnterToplay.Text = "Touch the screen to Play";
            m_EnterToplay.Position = new Vector2(CenterOfViewPort.X - (m_EnterToplay.Width / 2), CenterOfViewPort.Y + (m_WelcomeMessage.Height * 1.5f));
            m_EnterToplay.TintColor = Color.GreenYellow;

            //m_HToMainMenu.Text = "H to Main Menu";
            //m_HToMainMenu.Position = new Vector2(CenterOfViewPort.X - (m_HToMainMenu.Width / 2), m_EnterToplay.Position.Y + (m_EnterToplay.Height * 1.5f));
            //m_HToMainMenu.TintColor = Color.Black;

            m_EscToExit.Text = "Back to Exit";
            m_EscToExit.Position = new Vector2(CenterOfViewPort.X - (m_EscToExit.Width / 2), m_EnterToplay.Position.Y + (m_EnterToplay.Height * 1.5f));
            m_EscToExit.TintColor = Color.IndianRed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TouchCollection touchCol = TouchPanel.GetState();
            foreach (var touch in touchCol)
            {
                if (InputManager.KeyPressed(Keys.Enter) || touch.State == TouchLocationState.Pressed)
                {
                    ScreensManager.SetCurrentScreen(new LevelTransitionScreen(m_Game));
                    ScreensManager.Remove(this);
                }
            }
            //else if (InputManager.KeyPressed(Keys.H))
            //{
            //    ScreensManager.SetCurrentScreen(new MainMenuScreen(m_Game));
            //    ScreensManager.Remove(this);
            //}
            if (InputManager.KeyPressed(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.Back ==
    ButtonState.Pressed)
            {
                this.Game.Exit();
            }
        }
    }
}