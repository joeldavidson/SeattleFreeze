using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    class BaseCharacterModel : BaseModel
    {
     
        int health;
        int speed;
        int defense;
        int rangedDefense;

        double healthMult;
        double speedMult;
        double defenseMult;
        double rangedDefenseMult;

        bool dead;
        String ImageURI;
        int Level;
        int experienceTotal;
        ItemModel Head;
        ItemModel Feet;
        ItemModel Arms;
        ItemModel RightHand;
        ItemModel LeftHand;
        ItemModel LeftFinger;
        ItemModel RightFinger;
        String Ability;
        //Move[2] moveSet; --- Each character will have an array of 2 moves from which they can use attacks in battle. However, these moves structs must be designed and implemented.


        /*Required Methods
            Character() // default constructor
            Character() // Make a copy of a character constructor
            CharacterUpdate() //Update this with each attribute passed in
            String FormatOutput() //Text output of the class, a fancy toString()
            Bool ScaleLevel(int level) //Scale the character to the new level
            Bool LevelUp() //Levels up the character if they are ready
            Int levelUpToValue(int value) //Force leveling up to a level, say start a new character at level 5
            Bool AddExperience(int experience) // Add experience to current character
            Bool TakeDamage(int) //Character receives damage

            Int GetAttack()   //Return the calculated attack
            Int GetSpeed()
            Int GetDefense()
            Int GetMaxHealth()
            Int GetCurrentHealth()  //Return the calculated current health
            Int GetDamageDice()   //Get the dice to roll for the weapon used
            Int GetDamageRollValue()  //Get the calculated damage that this weapon rolled

            List<ItemModel> DropAllItems()  //Set of items the character drops when dead
            ItemModel RemoveItem(Location)  //Remove Item from location
            ItemModel GetItemByLocation(item) //Get Item info from Location
            ItemModel AddItem(Location,Item)  //Add item to location
            Int GetItemBonus(attribute)  //Get all the bonuses for the attribute

         */



    }
}
