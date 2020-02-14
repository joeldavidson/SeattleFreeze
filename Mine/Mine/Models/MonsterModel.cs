using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    //Enemie
    public class MonsterModel : BaseCharacterModel
    {
        //current xp give equation
        //(BASE_XP + (LVL_MULT * level) ^ LVL_EXP) = (1 + (2 * level) ^ 2)
        const int BASE_XP = 1;
        const int LVL_MULT = 2;
        const int LVL_EXP = 2;

        //Default monster image
        const string DEFAULT_URI = "sewer_gator.png";

        //Variable for experience given
        public uint experienceTotal { get; set; } = 1;
        
        //Item that is dropped by the monster
        ItemModel Drop = new ItemModel(); //should be retrieved at random?
        
        //Type of monster the player is facing
        public string type { get; set; } = "sewer creature";

        //Information available in the event of a monster being updated
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

        //The monster (inherits from base)
        public MonsterModel() : base()
        {
            imageURI = DEFAULT_URI;
        }

        //Levels up the Monster if they are ready
        bool LevelUp() 
        {
            level++;
            increaseStats();
            return true;
        }

        //Basic level up stat increases, temporary, will eventually change when classes are better hammered out
        void increaseStats() 
        {
            health += 5;
            defense += 2;
            rangedDefense += 2;
            speed += 2;
            attack += 2;
        }

        //Monster update
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

        //provides multipliers for stats that are increased with every level
        void levelMultipliers()
        {
            healthMult = 1;
            speedMult = 1;
            defenseMult = 1;
            rangedDefenseMult = 1;
            attackMult = 1;
        }

        //experience given by the monster
        public int dropExp()
        {
            return (BASE_XP + (LVL_MULT * level) ^ LVL_EXP);
        }

    }
}
