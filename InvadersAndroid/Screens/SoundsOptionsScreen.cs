﻿using System.Collections.Generic;
using Infrastructure.Menu;
using Infrastructure.ObjectModel.Screens;
using Invaders.Infrastructure;
using Invaders.InvadersMenu;
using Invaders.ObjectModel;

namespace Invaders.Screens
{
    public class SoundsOptionsScreen : GameScreen
    {
        private Menu m_Menu;

        public SoundsOptionsScreen(BaseGame i_Game)
            : base(i_Game)
        {
            Background background = new Background(i_Game, this, 1);
            SoundsOptionsCreatorScreen screenOptionsCreatorScreen = new SoundsOptionsCreatorScreen(i_Game, this);

            List<MenuItem> m_MenuItems = screenOptionsCreatorScreen.MakeMenu();
            m_Menu = new Menu(i_Game, m_MenuItems);
            this.Add(m_Menu);
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}