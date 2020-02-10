using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    class BaseCharacterModel : BaseModel
    {
        int NUM_MOVES = 2;
        struct move //we will eventually need to create another CRUDi for this
        {
            string type; //as in ranged or close or heal
            string name; 
            uint power;
            uint uses; // number of allowed uses per dungeon sequence
        }

        move[] moveSet = new move[2]; //--- Each character will have an array of 2 moves from which they can use attacks in battle.


        int level;
        int health;
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
        
       


        /*Required Methods
            Character() // default constructor
            Character() // Make a copy of a character constructor
            CharacterUpdate() //Update this with each attribute passed in
            String FormatOutput() //Text output of the class, a fancy toString()
            Bool ScaleLevel(int level) //Scale the character to the new level
            Bool LevelUp() //Levels up the character if they are ready
            Int levelUpToValue(int value) //Force leveling up to a level, say start a new character at level 5
            
            Bool TakeDamage(int) //Character receives damage

            Int GetAttack()   //Return the calculated attack
            Int GetSpeed()
            Int GetDefense()
            Int GetMaxHealth()
            Int GetCurrentHealth()  //Return the calculated current health
            Int GetDamageDice()   //Get the dice to roll for the weapon used
            Int GetDamageRollValue()  //Get the calculated damage that this weapon rolled

            List<ItemModel> DropAllItems()  //Set of items the character drops when dead
            

         */
      

    }
}
