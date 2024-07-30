using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            _selectFunc = new SelectFunc(SelectMenu);
        }

        public override void Update()
        {
            Console.Clear();

            if (_updateFunc != null)
            {
                _updateFunc();
            }

            if (_selectFunc != null)
            {
                _selectFunc();
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

            foreach (Item item in _parentCore.CurrentPlayer.Inventory)
            {
                Console.Write(item.Name);
                Console.Write(":");

                if (item.HealHP != 0)
                {
                    Console.Write(" HP 회복 {0},", item.HealHP);
                }

                if (item.AttPower != 0)
                {
                    Console.Write(" 공격력 증가 {0},", item.AttPower);
                }

                if(item.DefPower != 0)
                {
                    Console.Write(" 방어력 증가 {0},", item.DefPower);
                }

                if (item.CriticalPower != 0)
                {
                    Console.Write(" 크리티컬 데미지 증가 {0},", item.CriticalPower);
                }

                if (item.CriticalProb != 0)
                {
                    Console.Write(" 크리티컬 확률 증가 {0},", item.CriticalProb);
                }


                if (item.WeaponSkilled != 0)
                {
                    Console.Write(" 무기 숙련도 증가 {0},", item.WeaponSkilled);
                }            

                if (item.RemainTurn != 0)
                {
                    Console.Write(" 유지 기간 {0}턴", item.RemainTurn);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void SelectShopItem()
        {
            DevFunctions.WriteLineColored("구매하고 싶은 물건의 번호를 입력하세요.", ConsoleColor.Cyan);
            Console.WriteLine(); 

            Console.Write("1. 사과 : ");
            DevFunctions.WriteColored("30원", ConsoleColor.Red);
            DevFunctions.WriteLineColored("[사용시 HP를 50 회복합니다.]", ConsoleColor.Green);

            Console.Write("2. 배 : ");
            DevFunctions.WriteColored("50원", ConsoleColor.Red);
            DevFunctions.WriteLineColored("[사용시 HP를 100 회복합니다.]", ConsoleColor.Green);

            Console.Write("3. 필살의 영약 : ");
            DevFunctions.WriteColored("200원", ConsoleColor.Red);
            DevFunctions.WriteLineColored("[사용시 다음 공격의 크리티컬 확률이 50% 증가합니다.]", ConsoleColor.Green);

            Console.WriteLine("4. 구매를 종료합니다.");

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
                    BuyItem(ItemName.사과);
                    break;
                case 2:
                    BuyItem(ItemName.배);
                    break;
                case 3:
                    BuyItem(ItemName.필살의영약);
                    break;
                case 4:
                    _updateFunc = null;
                    _selectFunc = new SelectFunc(SelectMenu);
                    _shopMsg = null;
                    break;
            }
        }

        private void WriteShopMsg()
        {
            string Str = "소지 금액 : " + _parentCore.CurrentPlayer.Money.ToString();
            DevFunctions.WriteLineColored(Str, ConsoleColor.Yellow);

            if (_shopMsg != null)
            {
                DevFunctions.WriteLineColored(_shopMsg.Item1, _shopMsg.Item2);
            }
        }

        private void BuyItem(ItemName itemName)
        {
            if (Item.isCanBuy(_parentCore.CurrentPlayer, itemName) == true)
            {
                SetShopMsg_Buy(itemName);
                Item.BuyItem(_parentCore.CurrentPlayer, itemName);
            }
            else
            {
                SetShopMsg_Failed();
            }
        }

        private void SetShopMsg_Buy(ItemName itemName)
        {
            _shopMsg = new Tuple<string, ConsoleColor>(itemName.ToString() + "를 구매하였습니다.", ConsoleColor.Blue);
        }

        private void SetShopMsg_Failed()
        {
            _shopMsg = new Tuple<string, ConsoleColor>("소지 금액이 모자랍니다.", ConsoleColor.Red);
        }

        private void SelectMonster()
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
                return;
            }

            if (input.Length > 1)
            {
                return;
            }

            int toInt = int.Parse(input);

            switch (toInt)
            {
                case 4:
                    _selectFunc = new SelectFunc(SelectMenu);
                    break;
            }
        }

        private void SelectMenu()
        {
            Console.WriteLine("1. 캐릭터 정보를 확인한다.");
            Console.WriteLine("2. 인벤토리를 확인한다.");
            Console.WriteLine("3. 아이템을 구매한다.");
            Console.WriteLine("4. 전투를 시작한다.");
            Console.WriteLine("5. 게임을 종료한다.");

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

            if(toInt > 5)
            {
                return;
            }

            switch (toInt)
            {
                case 1:
                    _updateFunc = new UpdateFunc(WriteStatus);
                    _selectFunc = new SelectFunc(SelectMenu);
                    break;
                case 2:
                    _updateFunc = new UpdateFunc(WriteInventory);
                    _selectFunc = new SelectFunc(SelectMenu);
                    break;
                case 3:
                    _updateFunc = new UpdateFunc(WriteShopMsg);
                    _selectFunc = new SelectFunc(SelectShopItem);
                    break;
                case 4:
                    _updateFunc = null;
                    _selectFunc = new SelectFunc(SelectMonster);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }

        private UpdateFunc _updateFunc;
        private SelectFunc _selectFunc;
        private Tuple<string, ConsoleColor> _shopMsg;
    }
}
