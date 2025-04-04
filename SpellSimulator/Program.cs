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


            spellList.Add(new Spell("Fireball", 10, 0, 5, "Fire"));
            spellList.Add(new Spell("Magic Missiles", 2, 3, 2, "Arcane"));
            spellList.Add(spellCreator());

            ListAllSpells(spellList);


            ////////////////////////////////////////
            //////////MAIN GAMEPLAY LOOP////////////
            ////////////////////////////////////////
            while (true)
            {
                switch (currentGameState)
                {
                    case GameState.NonCombat:
                        Console.WriteLine("In a peaceful area");
                        break;

                    case GameState.Combat:
                        Console.WriteLine("WRAAAR!");
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
            for(int i = 0; i < _spellList.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + _spellList[i].spellName);
            }
        }
    }
}
