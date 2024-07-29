using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public abstract class GameLevel
    {
        protected GameLevel() { }

        public abstract void Update();

        protected GameCore _parentCore;

    }
}
