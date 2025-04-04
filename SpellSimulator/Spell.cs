using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellSimulator
{
    class Spell
    {
        public SpellState spellState { get; private set; }

        public string spellName;
        int spellDamage;
        int channelTime;
        int cooldownTimer;
        string spellType;

        public Spell(string _spellName, int _spellDamage, int _channelTime, int _cooldownTimer, string _spellType)
        {
            spellName = _spellName;
            spellDamage = _spellDamage;
            channelTime = _channelTime;
            cooldownTimer = _cooldownTimer;
            spellType = _spellType;
        }

    }
}
