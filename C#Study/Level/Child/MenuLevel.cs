using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class MenuLevel : GameLevel
    {
        private delegate void UpdateFunc();
        private delegate void SelectFunc();

        public MenuLevel(GameCore parrentCore)
        {
            _parentCore = parrentCore;

            selectfunc = new SelectFunc(SelectMenu);
        }

        public override void Update()
        {
            Console.Clear();

            if (updatefunc != null)
            {
                updatefunc();
            }

            if (selectfunc != null)
            {
                selectfunc();
            }
        }

        private void WriteStatus()
        {
            DevFunctions.WriteLineColored("착용중인 무기 정보", ConsoleColor.DarkCyan);

            Console.WriteLine("이름 : {0}  ", _parentCore.CurrentPlayer.EquipedWeapon.WPName);
            Console.WriteLine("공격력 : {0}  ", _parentCore.CurrentPlayer.EquipedWeapon.AttPower);
            Console.WriteLine("크리티컬 확률 : {0}%  ", _parentCore.CurrentPlayer.EquipedWeapon.CriticalProb);
            Console.WriteLine();

            DevFunctions.WriteLineColored("플레이어 스탯 정보", ConsoleColor.DarkCyan);
            Console.WriteLine("레벨 : {0}  ", _parentCore.CurrentPlayer.Level);
            Console.WriteLine("잔여 스탯 포인트 : {0}  ", _parentCore.CurrentPlayer.StatPoint);
            Console.WriteLine("공격력 : {0} ({1} + {2})  ", _parentCore.CurrentPlayer.AttPower + _parentCore.CurrentPlayer.EquipedWeapon.AttPower, _parentCore.CurrentPlayer.AttPower, _parentCore.CurrentPlayer.EquipedWeapon.AttPower);
            Console.WriteLine("크리티컬 확률 : {0} ({1} + {2})%  ", _parentCore.CurrentPlayer.CriticalProb + _parentCore.CurrentPlayer.EquipedWeapon.CriticalProb, _parentCore.CurrentPlayer.CriticalProb, _parentCore.CurrentPlayer.EquipedWeapon.CriticalProb);
            Console.WriteLine("크리티컬 데미지 : {0}%  ", _parentCore.CurrentPlayer.CriticalPower);
            Console.Write("무기 숙련도 : {0}  ", _parentCore.CurrentPlayer.WeaponSkilled);
            DevFunctions.WriteLineColored("*무기 숙련도가 높을수록 출혈, 회피, 기절 확률이 증가합니다.", ConsoleColor.DarkRed);
            Console.WriteLine("방어력 : {0}  ", _parentCore.CurrentPlayer.DefPower);
            Console.WriteLine("체력 : {0} / {1}  ", _parentCore.CurrentPlayer.CurrentHP, _parentCore.CurrentPlayer.MaxHP);
            Console.WriteLine("경험치 : {0} / {1}  ", _parentCore.CurrentPlayer.CurrentEXP, _parentCore.CurrentPlayer.MaxEXP);
            Console.WriteLine();
        }

        private void WriteInventory()
        {
            DevFunctions.WriteLineColored("보유 아이템 정보", ConsoleColor.DarkCyan);
            Console.WriteLine("아이템 개수 : {0}  ", _parentCore.CurrentPlayer.Inventory.Count);
            Console.WriteLine();
        }

        private void SelectMenu()
        {
            while (true)
            {
                Console.WriteLine("1. 캐릭터 정보를 확인한다.");
                Console.WriteLine("2. 인벤토리를 확인한다.");
                Console.WriteLine("3. 전투를 시작한다.");
                Console.WriteLine("4. 게임을 종료한다.");

                string input = Console.ReadLine();

                if (DevFunctions.IsNumeric(input) == false)
                {
                    continue;
                }

                if (input.Length > 1)
                {
                    continue;
                }

                int toInt = int.Parse(input);

                switch (toInt)
                {
                    case 1:
                        updatefunc = new UpdateFunc(WriteStatus);
                        break;
                    case 2:
                        updatefunc = new UpdateFunc(WriteInventory);
                        break;
                    case 3:
                        updatefunc = null;
                        selectfunc = new SelectFunc(SelectMonster);
                        break;
                }

                break;
            }
        }

        private void SelectMonster()
        {
            while (true)
            {
                DevFunctions.WriteLineColored("전투하고 싶은 몬스터를 선택하세요.", ConsoleColor.DarkCyan);
                Console.WriteLine();

                Console.WriteLine("1. 고블린 (적정 레벨 : 1)");
                Console.WriteLine("2. 오우거 (적정 레벨 : 5)");
                Console.WriteLine("3. 드래곤 (적정 레벨 : 10)");
                Console.WriteLine("4. 이전으로 돌아간다.");

                string input = Console.ReadLine();

                if (DevFunctions.IsNumeric(input) == false)
                {
                    continue;
                }

                if (input.Length > 1)
                {
                    continue;
                }

                int toInt = int.Parse(input);

                switch (toInt)
                {
                    case 4:
                        selectfunc = new SelectFunc(SelectMenu);
                        break;
                }
                break;
            }
        }

        private UpdateFunc updatefunc;
        private SelectFunc selectfunc;
    }
}
