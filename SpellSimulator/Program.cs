using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SpellSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState currentGameState = GameState.NonCombat;
            List<Spell> spellList = new List<Spell>();

            ListAllSpells(spellList);


            ////////////////////////////////////////
            //////////MAIN GAMEPLAY LOOP////////////
            ////////////////////////////////////////
            while (true)
            {
                switch (currentGameState)
                {
                    case GameState.NonCombat:
                        Console.WriteLine("You're in the village. What do you want to do?");
                        Console.WriteLine("1: Craft a new spell!");
                        Console.WriteLine("2. Examine Spellbook!");
                        Console.WriteLine("3: Sell loot!");
                        Console.WriteLine("3: Go out and fight monsters!");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        while(choice != 1 && choice != 2 && choice != 3)
                        {
                            Console.WriteLine("Invalid entry, try again");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        if(choice == 1)
                        {
                            spellList.Add(spellCreator());
                        }
                        if(choice == 2)
                        {
                            ListAllSpells(spellList);
                        }
                        if(choice == 3)
                        {
                            
                        }
                        if (choice == 4)
                        {
                            currentGameState = GameState.Combat;
                        }
                        choice = 0;

                        break;

                    case GameState.Combat:
                        Console.WriteLine("WRAAAR!");
                        Console.Read();
                        break;
                }
            }

        }

        public static Spell spellCreator()
        {
            Console.WriteLine("Enter spell name: ");
            string _spellName = Console.ReadLine();
            int _spellDamage = AssignNumericalValue("Enter spell damage: ");
            int _channelTime = AssignNumericalValue("Enter Channel Time (leave at 0 if you don't want any): ");
            int _coolDown = AssignNumericalValue("Enter Cooldown time: ");
            Console.WriteLine("Enter spell type: ");
            string _spellType = Console.ReadLine();

            return new Spell(_spellName, _spellDamage, _channelTime, _coolDown, _spellType);

            int AssignNumericalValue(string message)
            {
                int value;
                Console.WriteLine(message);
                while(!int.TryParse(Console.ReadLine(), out value)){
                    Console.WriteLine("Invalid entry, try again");
                }
                return value;
            }
        }

        public static void ListAllSpells(List<Spell> _spellList)
        {
            if(_spellList.Count == 0)
            {
                Console.WriteLine("Your spellbook is empty! Go craft some spells!");
                return;
            }

            for(int i = 0; i < _spellList.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + _spellList[i].spellName);
            }
        }
    }
}
