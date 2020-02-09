using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeAssault.Models
{
    class PlayerCharacter : BaseCharacterModel
    {
        int experienceTotal;
        ItemModel Head;
        ItemModel Arms;
        ItemModel RightHand;
        ItemModel RightFinger;
        ItemModel LeftHand;
        ItemModel LeftFinger;
        ItemModel Feet;

        ItemModel[] EquippedArray = new ItemModel[7]; //this array will (for the sake of convenience, contain all the equipment in the order presented above (Head[0], Arms[1], RightHand[2], RightFinger[3], LeftHand[4], LeftFinger[5], Feet[6])

        bool AddExperience(int experience) // Add experience to current character
        {
            return true;
        }
        ItemModel RemoveItem(string location)  //Remove Item from location
        {
            return Head;
        }
        ItemModel GetItemByLocation(string location) //Get Item info from Location
        {
            return Head;
        }
        void AddItem(string location, ItemModel item)  //Add item to location
        {
            
        }
        int GetItemBonus(string attribute)  //Get all the bonuses for the attribute
        {
            return 2;
        }
    }
}
