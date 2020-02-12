using PrimeAssault.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeAssault.Services
{
    public class MockCharDataStore : IDataStore<PlayerCharacterModel>
    {
        /// <summary>
        /// The Data List
        /// This is where the items are stored
        /// </summary>
        public List<ItemModel> datalist;
        public List<PlayerCharacterModel> datalist2;

        /// <summary>
        /// Constructor for the Storee
        /// </summary>
        public MockCharDataStore()
        {
            // Load the dataset
            LoadDefaultData();
        }

        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public bool LoadDefaultData()
        {
            datalist2 = new List<PlayerCharacterModel>()
            {
                new PlayerCharacterModel {Name = "Harvey II", Description = "He's a lean mean killing machine!"}
            };

            return true;
        }

        /// <summary>
        /// Add the data to the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> CreateAsync(PlayerCharacterModel data)
        {
            datalist2.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update the data with the information passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> UpdateAsync(PlayerCharacterModel data)
        {
            var oldData = datalist2.Where((PlayerCharacterModel arg) => arg.Id == data.Id).FirstOrDefault();
            datalist2.Remove(oldData);
            datalist2.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Deletes the Data passed in by
        /// Removing it from the list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var oldData = datalist2.Where((PlayerCharacterModel arg) => arg.Id == id).FirstOrDefault();
            datalist2.Remove(oldData);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Takes the ID and finds it in the data set
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record if found else null</returns>
        public async Task<PlayerCharacterModel> ReadAsync(string id)
        {
            return await Task.FromResult(datalist2.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Get the full list of data
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PlayerCharacterModel>> IndexAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(datalist2);
        }
    }
}