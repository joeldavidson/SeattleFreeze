using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    class BaseCharacterModel : BaseModel
    {
        const int NUM_MOVES = 2;
        class move //we will eventually need to create another CRUDi for this
        {
            string type; //as in ranged or close or heal
            string name; 
            uint power;
            uint uses; // number of allowed uses per dungeon sequence
        }

        move[] moveSet = new move[NUM_MOVES]; //--- Each character will have an array of 2 moves from which they can use attacks in battle.

        int level;
        int health;
        int maxHealth;
        int speed;
        int defense;
        int rangedDefense;

        double healthMult;
        double speedMult;
        double defenseMult;
        double rangedDefenseMult;

        bool dead;
        string imageURI;
        string ability;
        
        BaseCharacterModel() // default constructor which populates with the bare minimum stats any character can have
        {
            level = 1;
            health = 10;//
            maxHealth = 10;
            speed = 1;
            rangedDefense = 0;
            defense = 0;

            healthMult = 1;
            speedMult = 1;
            defenseMult = 1;
            rangedDefenseMult = 1;

            dead = false;
            ability = null;

            imageURI = null;

            for (int i = 0; i < NUM_MOVES; ++i)
                moveSet[i] = null;
            
        }
        void CharacterUpdate(int inHealth, int inTotalHealth, int inSpeed, int inRangedDefense, int inDefense) //Update this with each attribute passed in
        {

        }

        string FormatOutput() //Text output of the class, a fancy toString()
        {
            return "";
        }
        bool ScaleLevel(int level) //Scale the character to the new level
        {
            return true;
        }
        bool LevelUp() //Levels up the character if they are ready
        {
            return true;
        }
        int levelUpToValue(int value) //Force leveling up to a level, say start a new character at level 5
        {
            return 0;
        }
            
        bool TakeDamage(int attackVal) //Character receives damage
        {
            return true;
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
