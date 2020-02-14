namespace PrimeAssault.Models
{
    /// <summary>
    /// Item for the Game
    /// </summary>
    public class ItemModel : BaseModel
    {
        // the value of the item
        public int Value{get; set;} = 0;
        //Image for the item
        public string imageURI = "raygun.png";
        //what part of the body the item is located
        public string location { get; set; } = "head";
        //how much damage the item can do
        public int attackValue { get; set; } = 0;
        //what kind of defense bonus the item can add
        public int defenseValue { get; set; } = 0;
        //what kind of reanged defense bonus the item can add
        public int rangedDefenseValue { get; set; } = 0;
        //How much speed the item adds
        public int speedValue { get; set; } = 0;
        //How much health the item adds
        public int healthValue { get; set; } = 0;
        //What the attack multiplier for the item is
        public double attackMult { get; set; } = 0;
        //What the defense multiplier for the item has
        public double defenseMult { get; set; } = 0;
        //What the ranged defense multiplier for the item has
        public double rangedDefenseMult { get; set; } = 0;
        //What the speed multiplier for the item has
        public double speedMult { get; set; } = 0;
        //What the health multiplier for the item has
        public double healthMult { get; set; } = 0;


        //method that contains data for stats of items that can be updated
        public bool Update(ItemModel data)
        {
            Name = data.Name;
            Description = data.Description;
            location = data.location;
            attackValue = data.attackValue;
            defenseValue = data.defenseValue;
            rangedDefenseValue = data.rangedDefenseValue;
            speedValue = data.speedValue;
            healthValue = data.healthValue;

            attackMult = data.attackMult;
            defenseMult = data.defenseMult;
            rangedDefenseMult = data.rangedDefenseMult;
            speedMult = data.speedMult;
            healthMult = data.healthMult;

            Value = data.Value;
            return true;
        }

        //Method that determines what the value of each item is
        int getValue()
        {
            return attackValue + defenseValue + rangedDefenseValue + speedValue + healthValue;
        }

    }
}