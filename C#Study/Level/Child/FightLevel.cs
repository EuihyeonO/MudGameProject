using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class FightLevel : GameLevel
    {
        public FightLevel(GameCore parrentCore)
        {
            _parentCore = parrentCore;

  
        }

        public override void LevelStart()
        {
            _playerLog = null;
            _monsterLog = null;

            SelectedMonster = null;

            _messageFunc = new DMessageFunc(Message_FightMonster);
            _selectFunc = new DSelectFunc(Select_FightMonster);
        }

        public override void LevelEnd()
        {
            _playerLog = null;
            _monsterLog = null;

            SelectedMonster = null;
        }

        public void Message_Fight()
        {
            if(_selectedMonster == null)
            {
                return;
            }

            DevFunctions.WriteLineColored("플레이어 정보", ConsoleColor.Blue);
            Console.WriteLine("HP : {0} / {1}", _parentCore.CurrentPlayer.CurrentHP, _parentCore.CurrentPlayer.MaxHP);
            Console.WriteLine();

            DevFunctions.WriteLineColored("몬스터 정보", ConsoleColor.Red);
            Console.WriteLine("이름 : {0}", _selectedMonster.Name);
            Console.WriteLine("HP : {0} / {1}", _selectedMonster.CurrentHP, _selectedMonster.MaxHP);
            Console.WriteLine();

            if (_selectedMonster.CurrentHP <= 0)
            {
                Win();   
            }
            else if(_parentCore.CurrentPlayer.CurrentHP <= 0)
            {
                Lose();   
            }
            else
            {
                WriteFightLog();
            }
        }

        private void Win()
        {
            Console.WriteLine("전투에서 승리하였습니다!");

            _parentCore.CurrentPlayer.CurrentEXP += _selectedMonster.WinEXP;
            _parentCore.CurrentPlayer.Money += _selectedMonster.WinMoney;

            Console.WriteLine("아무 키나 입력시 메뉴 선택창으로 돌아갑니다.");

            Console.Read();

            _selectedMonster = null;
            _monsterLog = null;
            _playerLog = null;

            _parentCore.LevelChange(this, LevelType.Menu);
        }
        private void Lose()
        {
            Console.WriteLine("전투에서 패배하였습니다..");
            Console.WriteLine("아무 키나 입력시 메뉴 선택창으로 돌아갑니다.");

            Console.Read();

            _selectedMonster = null;
            _monsterLog = null;
            _playerLog = null;

            _parentCore.CurrentPlayer.CurrentHP = 1;
            _parentCore.LevelChange(this, LevelType.Menu);
        }

        private void WriteFightLog()
        {
            DevFunctions.WriteLineColored("나의 행동", ConsoleColor.Blue);
            
            if(_playerLog != null)
            {
                Console.WriteLine("{0}", _playerLog);
                Console.WriteLine();
            }

            DevFunctions.WriteLineColored("적의 행동", ConsoleColor.Red);
            if(_monsterLog != null)
            {
                Console.WriteLine("{0}", _monsterLog);
            }

            Console.WriteLine();
        }

        private void SelectBehavior()
        {
            Console.WriteLine("1. 공격한다.\n2. 아이템을 사용한다.\n3. 도망친다.");

            string input = Console.ReadLine();

            if (DevFunctions.IsNumeric(input) == false)
            {
                return;
            }

            if (input.Length > 1)
            {
                return;
            }

            int toInt = int.Parse(input);

            switch (toInt)
            {
                case 1:
                    PlayerAttack();
                    break;
            }

            MonsterBehavior();
        }

        private void PlayerAttack()
        {
            int Damage = GameFunctions.GetCalculatedDamage(_parentCore.CurrentPlayer, _selectedMonster);
            bool isCritical = GameFunctions.isCritical(_parentCore.CurrentPlayer);

            string CriticalMsg = "";

            if(isCritical == true) 
            {
                Damage = (int)(Damage * _parentCore.CurrentPlayer.CriticalPower);
                CriticalMsg = "[크리티컬!] ";
            }

            _playerLog = "적에게 공격 : " + CriticalMsg + Damage.ToString() + "의 피해를 입혔습니다.";

            _selectedMonster.CurrentHP -= Damage;
        }

        private void MonsterBehavior()
        {
            if(_selectedMonster.CurrentHP <= 0)
            {
                _monsterLog = "사망하였습니다.";
                _selectFunc = null;
                return;
            }

            int Damage = GameFunctions.GetCalculatedDamage(_selectedMonster, _parentCore.CurrentPlayer);
            bool isCritical = GameFunctions.isCritical(_selectedMonster);

            string CriticalMsg = "";

            if (isCritical == true)
            {
                Damage = (int)(Damage * _selectedMonster.CriticalPower);
                CriticalMsg = "[크리티컬!] ";
            }

            _monsterLog = "플레이어에게 공격 : " + CriticalMsg + Damage.ToString() + "의 피해를 입혔습니다.";

            _parentCore.CurrentPlayer.CurrentHP -= Damage;

            if(_parentCore.CurrentPlayer.CurrentHP <= 0)
            {
                _selectFunc = null;
            }
        }

        private void Select_FightMonster()
        {
            Console.WriteLine("1. 고블린 (적정 레벨 : 1)");
            //Console.WriteLine("2. 오우거 (적정 레벨 : 5)");
            //Console.WriteLine("3. 드래곤 (적정 레벨 : 10)");
            Console.WriteLine("4. 이전으로 돌아간다.");

            string input = Console.ReadLine();

            if (DevFunctions.IsNumeric(input) == false)
            {
                return;
            }

            if (input.Length > 1)
            {
                return;
            }

            int toInt = int.Parse(input);

            switch (toInt)
            {
                case 1:
                    _selectedMonster = new Goblin();
                    break;
                case 4:
                    _parentCore.LevelChange(this, LevelType.Menu);
                    _selectedMonster = null;

                    _messageFunc = new DMessageFunc(Message_FightMonster);
                    _selectFunc = new DSelectFunc(Select_FightMonster);

                    return;
            }

            _messageFunc = new DMessageFunc(Message_Fight);
            _selectFunc = new DSelectFunc(SelectBehavior);
        }

        private void Message_FightMonster()
        {
            DevFunctions.WriteLineColored("전투하고 싶은 몬스터를 선택하세요.", ConsoleColor.DarkCyan);
            Console.WriteLine();       
        }

        public static Monster SelectedMonster
        {
            get { return _selectedMonster; }
            set { _selectedMonster = value; }
        }

        private static Monster _selectedMonster;
        private static string _playerLog;
        private static string _monsterLog;
    }
}
