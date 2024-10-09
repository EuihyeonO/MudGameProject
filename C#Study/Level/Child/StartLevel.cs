using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class StartLevel : GameLevel
    {
        public StartLevel(GameCore parrentCore)
        {
            _parentCore = parrentCore;
        }

        public override void LevelStart()
        {
            _messageFunc = new DMessageFunc(MessageFunc);
            _selectFunc = new DSelectFunc(SelectFunc);
        }

        public override void LevelEnd()
        {

        }

        public void MessageFunc()
        {
            Console.Clear();

            Console.WriteLine("*************************************************");
            Console.WriteLine("*************************************************");

            Console.Write("*****************");
            DevFunctions.WriteColored("전사의 모험 RPG", ConsoleColor.Yellow);
            Console.WriteLine("*****************");

            Console.Write("******************");
            DevFunctions.WriteColored("제작자 오의현", ConsoleColor.Yellow);
            Console.WriteLine("******************");

            Console.WriteLine("*************************************************");
            Console.WriteLine("*************************************************");
            Console.WriteLine();

            Console.WriteLine("모험을 시작하시겠습니까?");
        }

        public void SelectFunc()
        {
            DevFunctions.WriteLineColored("1 : YES", ConsoleColor.Blue);
            DevFunctions.WriteLineColored("2 : NO", ConsoleColor.Red);

            string input = Console.ReadLine();

            if (DevFunctions.IsNumeric(input) == false)
            {
                return;
            }

            int toInt = int.Parse(input);

            switch (toInt)
            {
                case 1:
                    _parentCore.LevelChange(this, LevelType.Setting);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
