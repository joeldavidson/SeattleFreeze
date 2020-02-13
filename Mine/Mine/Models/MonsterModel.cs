using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    public class MonsterModel : BaseCharacterModel
    {
        //current xp give equation
        //(BASE_XP + (LVL_MULT * level) ^ LVL_EXP) = (1 + (2 * level) ^ 2)
        const int BASE_XP = 1;
        const int LVL_MULT = 2;
        const int LVL_EXP = 2;

        const string DEFAULT_URI = "sewer_gator.png";

        public uint experienceTotal { get; set; } = 0;
        
        ItemModel Drop = new ItemModel(); //should be retrieved at random?
        
        public int Value { get; set; } = 0;

        public bool Update(MonsterModel data)
        {
            Name = data.Name;
            Description = data.Description;
            level = data.level;
            health = data.health;
            maxHealth = data.maxHealth;
            speed = data.speed;
            attack = data.attack;
            rangedDefense = data.rangedDefense;
            defense = data.defense;

            healthMult = data.healthMult;
            speedMult = data.speedMult;
            defenseMult = data.defenseMult;
            rangedDefenseMult = data.rangedDefense;
            attackMult = data.attackMult;

            dead = false;
            ability = null;
            return true;
        }

        public MonsterModel() : base()
        {
            imageURI = "sewer_monster.png";
        }

        int GetItemBonus()  //Get all the bonuses for the attributes (should be incorporated after items)
        {
            return 0;
        }

        bool LevelUp() //Levels up the Monster if they are ready
        {
            level++;
            increaseStats();
            return true;
        }

        void increaseStats() //Basic level up stat increases, temporary, will eventually change when classes are better hammered out
        {
            health += 5;
            defense += 2;
            rangedDefense += 2;
            speed += 2;
            attack += 2;
        }

        void MonsterUpdate(MonsterModel data)
        {
            health = data.health;
            maxHealth = data.maxHealth;
            speed = data.speed;
            rangedDefense = data.rangedDefense;
            defense = data.defense;
            attack = data.attack;
            Description = data.Description;
            Name = data.Name;
            level = data.level;
        }

        void levelMultipliers()
        {
            healthMult = 1;
            speedMult = 1;
            defenseMult = 1;
            rangedDefenseMult = 1;
            attackMult = 1;
        }

        
        
    }
}
