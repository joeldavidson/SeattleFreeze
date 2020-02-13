using PrimeAssault.Services;
using PrimeAssault.Models;
using PrimeAssault.Views;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace PrimeAssault.ViewModels
{
    public class MonIndexViewModel : BaseViewModel
    {
        // The Data set of records
        public ObservableCollection<MonsterModel> Dataset { get; set; }

        /// <summary>
        /// Connection to the Data store
        /// </summary>
        public IDataStore<MonsterModel> DataStore => DependencyService.Get<IDataStore<MonsterModel>>();

        // Command to force a Load of data
        public Command LoadDatasetCommand { get; set; }

        private bool _needsRefresh;

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public MonIndexViewModel()
        {
            Title = "Monsters";

            Dataset = new ObservableCollection<MonsterModel>();
            LoadDatasetCommand = new Command(async () => await ExecuteLoadDataCommand());

            // Register the Create Message
            MessagingCenter.Subscribe<MonCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            {
                await Add(data as MonsterModel);
            });

            MessagingCenter.Subscribe<MonDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            {
                await Delete(data as MonsterModel);
            });

            MessagingCenter.Subscribe<MonUpdatePage, MonsterModel>(this, "Update", async (obj, data) =>
            {
                await Update(data as MonsterModel);
            });
        }
        /// <summary>
        /// API to add the Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> Add(MonsterModel data)
        {
            Dataset.Add(data);
            var result = await DataStore.CreateAsync(data);

            return true;
        }

        public async Task<bool> Delete(MonsterModel data)
        {
            var record = await Read(data.Id);
            if (record == null)
            {
                return false;
            }
            Dataset.Remove(data);

            var result = await DataStore.DeleteAsync(data.Id);

            await ExecuteLoadDataCommand();

            return result;
        }

        public async Task<bool> Update(MonsterModel data)
        {
            var record = await Read(data.Id);
            if (record == null)
            {
                return false;
            }
            record.Update(data);

            var result = await DataStore.UpdateAsync(record);
            await ExecuteLoadDataCommand();

            return result;
        }

        public async Task<MonsterModel> Read(string id)
        {
            var result = await DataStore.ReadAsync(id);
            return result;
        }

        #region Refresh
        // Return True if a refresh is needed
        // It sets the refresh flag to false
        public bool NeedsRefresh()
        {
            if (_needsRefresh)
            {
                _needsRefresh = false;
                return true;
            }

            return false;
        }

        // Sets the need to refresh
        public void SetNeedsRefresh(bool value)
        {
            _needsRefresh = value;
        }

        // Command that Loads the Data
        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var dataset = await DataStore.IndexAsync(true);

                // Example of how to sort the database output using a linq query.
                // Sort the list
                dataset = dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();

                foreach (var data in dataset)
                {
                    Dataset.Add(data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Force data to refresh
        /// </summary>
        public void ForceDataRefresh()
        {
            // Reset
            var canExecute = LoadDatasetCommand.CanExecute(null);
            LoadDatasetCommand.Execute(null);
        }
        #endregion Refresh
    }
}