using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Windows.Input;
using task_12._1.Model;
using System.IO;
using System.Collections.ObjectModel;

namespace task_12._1.ViewModel
{
    public class AddClientViewModel : MainViewModel
    {
        public ICommand AddClientCommand { get; private set; }

        public Client NewClient { get; set; }

        public AddClientViewModel()
        {
            AddClientCommand = new DelegateCommand(AddClient, CanBeAdded);
            NewClient = new Client();
        }

        public AddClientViewModel(ObservableCollection<Client> clients)
        {
            AddClientCommand = new DelegateCommand(AddClient, CanBeAdded);
            NewClient = new Client();
            ClientsCollection = clients;
        }

        private void InFile()
        {
            JArray clientsArray = new JArray();
            foreach (Client client in ClientsCollection)
            {
                clientsArray.Add(client.GetJson());
            }

            using (StreamWriter stream = new StreamWriter(fileName))
            {
                string json = JsonConvert.SerializeObject(clientsArray, Formatting.Indented);
                stream.Write(json);
            }
        }

        private void AddClient(object obj)
        {
            ClientsCollection.Add(NewClient);
            InFile();
        }

        private bool CanBeAdded(object arg)
        {
            return NewClient.FullName.Surname != null && NewClient.FullName.Name != null && 
                NewClient.PhoneNumber.ToString().Length > 10 &&
                NewClient.Passport.ToString().Length == 9;
        }
    }
}
