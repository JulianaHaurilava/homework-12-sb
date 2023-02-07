using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace task_12._1
{
    public class MainViewModel
    {
        private string fileName;

        public Client SelectedClient { get; set; }
        public ObservableCollection<Client> ClientsCollection { get; set; }

        


        public MainViewModel()
        {
            fileName = "clients.json";
            ClientsCollection = new ObservableCollection<Client>();
            
            OutOfFile();
        }

        /// <summary>
        /// Индексатор, находящий клиента по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Client this[PhoneNumber phoneNumber]
        {
            get
            {
                foreach (Client client in ClientsCollection)
                {
                    if (client.PhoneNumber == phoneNumber)
                        return client;
                }
                return null;
            }
        }

        private void NewClientInFile(Client newClient)
        {
            //File.AppendAllText(fileName, newClient.GetJson());
        }

        private void OutOfFile()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader stream = new StreamReader(fileName, true))
                {
                    string json = stream.ReadToEnd();
                    if (json.Length != 0)
                    {
                        ClientsCollection = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
                    }
                }
            }
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

        private AddClient()
        {
            ClientsCollection.Add(newClient);
            InFile();
        }
        public void AddNewClient(Client newClient)
        {
            
        }
        public void DeleteClient(Client clientToDelete)
        {
            ClientsCollection.Remove(clientToDelete);
            InFile();
        }
    }
}
