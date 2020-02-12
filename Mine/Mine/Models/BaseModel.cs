using System;

namespace PrimeAssault.Models
{
    /// <summary>
    /// Base model for records that get saved
    /// </summary>
    public class BaseModel
    {
        // ID
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Name 
        public string Name { get; set; } = "";

        // Description
        public string Description { get; set; } = "Description";
    }
}