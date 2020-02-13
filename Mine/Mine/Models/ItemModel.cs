namespace PrimeAssault.Models
{
    /// <summary>
    /// Item for the Game
    /// </summary>
    public class ItemModel : BaseModel
    {
        // the value of the item
        public int Value{get; set;} = 0;

        public string imageURI = "raygun.png";
        public string location { get; set; } = "head";
        public int attackValue { get; set; } = 0;
        public int defenseValue { get; set; } = 0;
        public int rangedDefenseValue { get; set; } = 0;
        public int speedValue { get; set; } = 0;
        public int healthValue { get; set; } = 0;

        public double attackMult { get; set; } = 0;
        public double defenseMult { get; set; } = 0;
        public double rangedDefenseMult { get; set; } = 0;
        public double speedMult { get; set; } = 0;
        public double healthMult { get; set; } = 0;



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

        int getValue()
        {
            return attackValue + defenseValue + rangedDefenseValue + speedValue + healthValue;
        }

    }
}