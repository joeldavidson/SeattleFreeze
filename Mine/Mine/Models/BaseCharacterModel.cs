using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    public class BaseCharacterModel : BaseModel
    {
        const int NUM_MOVES = 2;
        class move //we will eventually need to create another class for this
        {
            string type; //as in ranged or close or heal
            string name; 
            uint power;
            uint uses; // number of allowed uses per dungeon sequence
        }

        move[] moveSet = new move[NUM_MOVES]; //--- Each character will have an array of 2 moves from which they can use attacks in battle.

        public int level { get; set; } = 1;
        public int health { get; set; } = 10;
        public int maxHealth { get; set; } = 10;
        public int speed { get; set; } = 2;
        public int defense { get; set; } = 2;
        public int rangedDefense { get; set; } = 2;
        public int attack { get; set; } = 2;

        public double healthMult { get; set; } = 1.0;
        public double speedMult { get; set; }= 1.0;
        public double defenseMult { get; set; } = 1.0;
        public double rangedDefenseMult { get; set; } = 1.0;
        public double attackMult { get; set; } = 1.0;

        public bool dead { get; set; } = false;
        public string imageURI { get; set; } = "TempProfile.png";
        public string ability { get; set; } = "None";
        
        public BaseCharacterModel() // default constructor which populates with the bare minimum stats any character can have
        {
            for (int i = 0; i < NUM_MOVES; ++i)
                moveSet[i] = null;
        }

        string FormatOutput() //Text output of the class, a fancy toString()
        {
            return ("Name: " + Name + "/nDescription: " + Description);
        }
        bool ScaleLevel(int level) //Scale the character to the new level
        {
            return true;
        }
       
        int levelUpToValue(int value) //Force leveling up to a level, say start a new character at level 5
        {
            return 0;
        }
            
        bool TakeDamage(int damVal) //Character receives damage
        {
            if (health == 0)
                return false;
            else
            {
                health -= damVal;
                if (health <=0)
                {
                    health = 0;
                    dead = true;
                }
                return true;
            }
        }

        int GetAttack()   //Return the calculated attack
        {
            return 0;
        }
        int GetSpeed()
        {
            return 0;
        }
        int GetDefense()
        {
            return 0;
        }
        int GetMaxHealth()
        {
            return 0;
        }
        int GetCurrentHealth()  //Return the calculated current health
        {
            return 0;
        }
        int GetDamageDice()   //Get the dice to roll for the weapon used
        {
            return 0;
        }
        int GetDamageRollValue()  //Get the calculated damage that this weapon rolled
        {
            return 0;
        }

        List<ItemModel> DropAllItems()  //Set of items the character drops when dead
        {
            List<ItemModel> droppedItems = new List<ItemModel>();
            //insert code here

            return droppedItems;
        }

    }
}
