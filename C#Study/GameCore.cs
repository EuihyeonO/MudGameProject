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
        Play,
    }

    public class GameCore
    {
        public void Start()
        {
            _player = new Player();
            _levelType = LevelType.Start;
        }

        public void Update()
        {
            while(_player != null)
            {
                switch (_levelType)
                {
                    case LevelType.Start:
                        StartLevelUpdate();
                        break;
                    case LevelType.Play:
                        PlayLevelUpdate();
                        break;
                }
            }
        }

        private void StartLevelUpdate()
        {
            while (_levelType == LevelType.Start)
            {
                Console.Clear();

                Console.WriteLine("*************************************************");
                Console.WriteLine("*************************************************");
               
                Console.Write("*****************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("전사의 모험 RPG");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("*****************");

                Console.Write("******************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("제작자 오의현");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("******************");

                Console.WriteLine("*************************************************");
                Console.WriteLine("*************************************************");
                Console.WriteLine();

                Console.WriteLine("모험을 시작하시겠습니까?");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1 : YES");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2 : NO");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();

                if (DevFunctions.IsNumeric(input) == false)
                {
                    continue;
                }

                int toInt = int.Parse(input);

                switch (toInt)
                {
                    case 1:
                        _levelType = LevelType.Play;
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void PlayLevelUpdate()
        {
            while (_levelType == LevelType.Play)
            {
                Console.Clear();

                Console.WriteLine("**************************************************");
                Console.WriteLine("*****시작*****");
                Console.WriteLine("**************************************************");
                Console.WriteLine();

                string input = Console.ReadLine();

                if (DevFunctions.IsNumeric(input) == false)
                {
                    continue;
                }

                int toInt = int.Parse(input);
            }
        }

        private Player _player;
        private LevelType _levelType;
    }
}

