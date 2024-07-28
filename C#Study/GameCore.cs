using C_Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Study
{
    public enum LevelType
    {
        Start,
        Setting,
        Menu,
        Play,
    }

    public class GameCore
    {

        public void Start()
        {
            _player = new Player();
            _levelType = LevelType.Start;

            _levels = new Dictionary<LevelType, GameLevel>();

            _levels.Add(LevelType.Start, new StartLevel(this));
            _levels.Add(LevelType.Setting, new SettingLevel(this));
            _levels.Add(LevelType.Menu, new MenuLevel(this));
        }

        public void Update()
        {
            while (_player != null)
            {
                _levels[_levelType].Update();
            }
        }

        public void End()
        {

        }

        public LevelType CurrentLevel
        {
            set { _levelType = value; }
        }

        public Player CurrentPlayer
        {
            get { return _player; }
        }

        private Player _player;
        private LevelType _levelType;

        private Dictionary<LevelType, GameLevel> _levels;
    }
}

