using PrimeAssault.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeAssault.Services
{
    public class MockMonDataStore : IDataStore<MonsterModel>
    {
        /// <summary>
        /// The Data List
        /// This is where the items are stored
        /// </summary>
        public List<MonsterModel> datalist2;

        /// <summary>
        /// Constructor for the Storee
        /// </summary>
        public MockMonDataStore()
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
            datalist2 = new List<MonsterModel>()
            {
                new MonsterModel {Name = "Evil Harvey", Description = "He's a lean mean killing machine!", attack = 500}
            };

            return true;
        }

        /// <summary>
        /// Add the data to the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> CreateAsync(MonsterModel data)
        {
            datalist2.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update the data with the information passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> UpdateAsync(MonsterModel data)
        {
            var oldData = datalist2.Where((MonsterModel arg) => arg.Id == data.Id).FirstOrDefault();
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
            var oldData = datalist2.Where((MonsterModel arg) => arg.Id == id).FirstOrDefault();
            datalist2.Remove(oldData);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Takes the ID and finds it in the data set
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record if found else null</returns>
        public async Task<MonsterModel> ReadAsync(string id)
        {
            return await Task.FromResult(datalist2.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Get the full list of data
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MonsterModel>> IndexAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(datalist2);
        }
    }
}