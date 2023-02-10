using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Windows.Input;
using task_12._1.Model;
using System.IO;

namespace task_12._1.ViewModel
{
    public class AddClientViewModel : MainViewModel
    {
        public ICommand AddCommand { get; private set; }

        private Client newClient;

        public AddClientViewModel()
        {
            AddCommand = new DelegateCommand(AddNewClient, CanBeAdded);
            newClient = new Client();
        }

        

        private void NewClientInFile(Client newClient)
        {
            //File.AppendAllText(fileName, newClient.GetJson());
        }


        private void InFile()
        {
            JArray clientsArray = new JArray();
            foreach (Client client in ClientsCollection)
            {
                clientsArray.Add(client.GetJson());
            }

            //using (StreamWriter stream = new StreamWriter(fileName))
            //{
            //    string json = JsonConvert.SerializeObject(clientsArray, Formatting.Indented);
            //    stream.Write(json);
            //}
        }

        private void AddClient()
        {
            ClientsCollection.Add(newClient);
            InFile();
        }

        private bool CanBeAdded(object arg)
        {
            return newClient.FullName.Surname != "" && newClient.FullName.Name != "" &&
                newClient.FullName.Patronymic != "" && newClient.PhoneNumber.ToString() != "" &&
                newClient.Passport.ToString() != "";
        }

        private void AddNewClient(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
