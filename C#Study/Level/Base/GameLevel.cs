using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public abstract class GameLevel
    {
        protected delegate void DMessageFunc();
        protected delegate void DSelectFunc();

        protected GameLevel() { }
         
        public void Update()
        {
            Console.Clear();

            if(_messageFunc != null)
            {
                _messageFunc();
            }

            if(_selectFunc != null)
            {
                _selectFunc();
            }
        }

        public abstract void LevelStart();
        public abstract void LevelEnd();

        protected GameCore _parentCore;

        protected DMessageFunc _messageFunc;
        protected DSelectFunc _selectFunc;
    }
}
