using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    public class PlayerCharacterModel : BaseCharacterModel
    {
        const int NUM_SLOTS = 7;

        //current level up equation
        //(BASE_XP + (LVL_MULT * level) ^ LVL_EXP) = (100 + (5 * level) ^ 2)
        const int BASE_XP = 100;
        const int LVL_MULT = 5;
        const int LVL_EXP = 2;

        const string DEFAULT_CLASS = "soldier";

        uint experienceTotal;
        uint nextLevel;
        double nextLevelMultiplier;
        string jobClass;
        
        /*
        ItemModel Head;
        ItemModel Arms;
        ItemModel RightHand;
        ItemModel RightFinger;
        ItemModel LeftHand;
        ItemModel LeftFinger;
        ItemModel Feet;
        */
        ItemModel[] EquippedArray = new ItemModel[NUM_SLOTS]; //this array will (for the sake of convenience, contain all the equipment in the order presented above (Head[0], Arms[1], RightHand[2], RightFinger[3], LeftHand[4], LeftFinger[5], Feet[6])
        
        public int Value { get; set; } = 0;
        public bool Update(PlayerCharacterModel data)
        {
            Name = data.Name;
            Description = data.Description;
            jobClass = data.jobClass;
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

        enum jobList //might use in the future to make more tenable code that looks more like Dr. Koenig's, keeping as reminder
        {
            Soldier,
            Hunter,
            Brawler,
            Mechanist,
            Mechanic,
            Ringleader
        }

        public PlayerCharacterModel()
        {
            experienceTotal = 0; // will have to flesh out more if character is created at higher level. Might want constructor which takes int for level
            nextLevel = 100;
            
            for (int i = 0; i < NUM_SLOTS; ++i)
                EquippedArray[i] = null;

            jobClass = DEFAULT_CLASS;
            updateClass();
        }
        
        bool AddExperience(uint experience) // Add experience to current character
        {
            experienceTotal += experience;
            LevelUp();
            return true;
        }

        ItemModel RemoveItem(string location)  //Remove Item from location by setting old location to null. Returns the old item.
        {
            int index = translateLocationNameToArrayLocation(location);
            ItemModel RemovedItem = EquippedArray[index];
            EquippedArray[index] = null;
            return RemovedItem;
        }

        ItemModel GetItemByLocation(string location) //Get Item info from Location
        {
            int index = translateLocationNameToArrayLocation(location);
            ItemModel ExamineItem = EquippedArray[index];
            return ExamineItem;
        }

        bool AddItem(string location, ItemModel item)  //Add item to location
        {
            if (GetItemByLocation(location) == null)
            {
                int index = translateLocationNameToArrayLocation(location);
                EquippedArray[index] = item;
                return true;
            }
            return false;
        }

        int GetItemBonus()  //Get all the bonuses for the attributes (should be incorporated after items)
        {
            return 0;
        }

        bool LevelUp() //Levels up the character if they are ready
        {
            if (experienceTotal >= (nextLevel))
            {
                ++level;
                increaseStats();
                nextLevel += (uint)((BASE_XP + (LVL_MULT * level) ^ LVL_EXP) * nextLevelMultiplier);
                return true;
            }
            return false;
        }

        void increaseStats() //Basic level up stat increases, temporary, will eventually change when classes are better hammered out
        {
            health += 5;
            defense += 2;
            rangedDefense += 2;
            speed += 2;
            attack += 2;
        }

        int translateLocationNameToArrayLocation(string location) //Helper function which maps equip locations to array indices
        {
            location = location.ToLower();
            if (location == "head")
                return 0;
            else if (location == "arms")
                return 1;
            else if (location == "righthand")
                return 2;
            else if (location == "rightfinger")
                return 3;
            else if (location == "lefthand")
                return 4;
            else if (location == "leftfinger")
                return 5;
            else if (location == "feet")
                return 6;
            else
                return -1;
        }

        void CharacterUpdate(PlayerCharacterModel data)
        {
            health = data.health;
            maxHealth = data.maxHealth;
            speed = data.speed;
            rangedDefense = data.rangedDefense;
            defense = data.defense;
            attack = data.attack;
            Description = data.Description;
            Name = data.Name;
            jobClass = data.jobClass.ToLower();
            updateClass();
        }

        void levelMultipliers()
        {
            healthMult = 1;
            speedMult = 1;
            defenseMult = 1;
            rangedDefenseMult = 1;
            attackMult = 1;
        }

        bool updateClass()//ugly awful class, not maintanable, needs work. So sorry to everyone, just trying to get class up on its feet. Hardcode galore.
        {
            if (jobClass == "soldier") //helper class with default values for each class
            {
                levelMultipliers();
                healthMult += .2;
                speedMult += -.1;
                defenseMult += .3;
                rangedDefenseMult += -.3;
                attackMult += .2;
                Description = "Soldiers have high health, and defense, and are more likely to get abilities that help with close-range combat.";
                jobClass = "Soldier";
                nextLevelMultiplier = 1.0;
                imageURI = "soldier_class.png";
                return true;
            }
            if (jobClass == "hunter")
            {
                levelMultipliers();
                healthMult += -.3;
                speedMult += .3;
                defenseMult += 0;
                rangedDefenseMult += .15;
                attackMult += .15;
                Description = "The hunter has high Attack, and Speed and its bonuses usually lend to killing sewer creatures from afar.";
                jobClass = "Hunter";
                nextLevelMultiplier = 1.0;
                imageURI = "hunter_class.png";
                return true;
            }
            if (jobClass == "brawler")
            {
                levelMultipliers();
                healthMult += .5;
                speedMult += -.5;
                defenseMult += .15;
                rangedDefenseMult += .15;
                attackMult += .05;
                Description = "The brawler is a beef-cake with high overall survivability, but no amazing offensive power.";
                jobClass = "Brawler";
                nextLevelMultiplier = 1.1;
                imageURI = "brawler_class.png";
                return true;
            }
            if (jobClass == "mechanic")
            {
                levelMultipliers();
                healthMult += -.2;
                speedMult += .4;
                defenseMult += -.2;
                rangedDefenseMult += .2;
                attackMult += -.25;
                Description = "Mechanic has low overall stats, but all mechanic abilities allow for healing of teammates.";
                jobClass = "Mechanic";
                nextLevelMultiplier = 1.2;
                imageURI = "mechanic_class.png";
                return true;
            }
            if (jobClass == "mechanist")
            {
                levelMultipliers();
                healthMult += 0;
                speedMult += 0;
                defenseMult += .1;
                rangedDefenseMult += .1;
                attackMult += .1;
                Description = "The mechanist has high ranged defense and attack, and its bonuses are good for killing Euphrates mechs.";
                jobClass = "Mechanist";
                nextLevelMultiplier = 1.1;
                imageURI = "mechanist_class.png";
                return true;
            }
            if (jobClass == "ringleader")
            {
                levelMultipliers();
                healthMult += -.1;
                speedMult += -.1;
                defenseMult += -.1;
                rangedDefenseMult += -.1;
                attackMult += -.1;
                Description = "A ringleader has low base stats, but compensates for this through its ability to channel 10 rings to great possible effect.";
                jobClass = "Ringleader";
                nextLevelMultiplier = 1.3;
                imageURI = "ringleader_class.png";
                return true;
            }
            return false;
        }
    }
}
