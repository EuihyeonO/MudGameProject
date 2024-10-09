using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class SettingLevel : GameLevel
    {
        public SettingLevel(GameCore parrentCore)
        {
            _parentCore = parrentCore;
        }

        public override void LevelStart()
        {
            _messageFunc = new DMessageFunc(WeaponSelectMessage);
            _selectFunc = new DSelectFunc(WeaponSelect);
        }

        public override void LevelEnd()
        {

        }

        private void WeaponSelectMessage()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("----------------캐릭터 설정 단계-----------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();

            DevFunctions.WriteLineColored("무기 선택 단계입니다.", ConsoleColor.Cyan);
            Console.WriteLine();

            Console.WriteLine("검은 기본 공격력이 낮지만 크리티컬 확률이 가장 높습니다.");
            Console.WriteLine("공격시 일정 확률로 출혈을 발생시키기도 합니다.");
            Console.WriteLine();

            Console.WriteLine("창은 적당한 공격력과 크리티컬 확률을 보유하고 있습니다.");
            Console.WriteLine("피격시 일정 확률로 적의 공격을 회피합니다.");
            Console.WriteLine();

            Console.WriteLine("망치는 높은 공격력을 보유하고 있지만 크리티컬 확률이 낮습니다.");
            Console.WriteLine("공격시 일정 확률로 적을 기절 상태로 만듭니다.");
            Console.WriteLine();          
        }

        private void WeaponSelect()
        {
            Console.WriteLine("어떤 무기를 선택하시겠습니까?");
            DevFunctions.WriteColored("1.오래된 검 ", ConsoleColor.Blue);
            DevFunctions.WriteColored("2.오래된 창 ", ConsoleColor.Red);
            DevFunctions.WriteColored("3.오래된 망치", ConsoleColor.Green);
            Console.WriteLine();

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

            if(toInt > 3 || toInt <= 0)
            {
                return;
            }

            switch (toInt)
            {
                case 1:
                    _parentCore.CurrentPlayer.EquipedWeapon = new OldSword();
                    break;
                case 2:
                    _parentCore.CurrentPlayer.EquipedWeapon = new OldSpear();
                    break;
                case 3:
                    _parentCore.CurrentPlayer.EquipedWeapon = new OldHammer();
                    break;
            }

            _messageFunc = new DMessageFunc(WeaponFixMessage);
            _selectFunc = new DSelectFunc(WeaponFixSelect);
        }

        private void WeaponFixMessage()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("----------------캐릭터 설정 단계-----------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();

            Console.Write("선택하신 무기는 ");
            DevFunctions.WriteColored(_parentCore.CurrentPlayer.EquipedWeapon.WPName, ConsoleColor.Cyan);
            Console.Write("입니다.");
            Console.WriteLine();
        }

        private void WeaponFixSelect()
        {
            Console.WriteLine("선택하신 무기로 게임을 시작하시겠습니까?");
            DevFunctions.WriteLineColored("1. 네", ConsoleColor.Blue);
            DevFunctions.WriteLineColored("2. 다시 선택할래요", ConsoleColor.Red);

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

            if(toInt != 1 && toInt != 2)
            {
                return;
            }

            switch (toInt)
            {
                case 1:
                    _parentCore.LevelChange(this, LevelType.Menu); 
                    break;
                case 2:
                    _messageFunc = new DMessageFunc(WeaponSelectMessage);
                    _selectFunc = new DSelectFunc(WeaponSelect);

                    break;
            }
        }
    }
}
