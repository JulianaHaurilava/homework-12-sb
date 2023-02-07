using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Principal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace task_12._1
{
    public class ViewModel
    {
        private string fileName;
        private Client selectedClient;

        ObservableCollection<Client> clients;

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
            }
        }
        public ViewModel()
        {
            fileName = "clients.json";
            clients = new ObservableCollection<Client>();
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
                foreach (Client client in clients)
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
                        clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
                    }
                }
            }
        }

        private void InFile()
        {
            JArray clientsCollection = new JArray();
            foreach (Client client in clients)
            {
                clientsCollection.Add(client.GetJson());
            }

            using (StreamWriter stream = new StreamWriter(fileName))
            {
                string json = JsonConvert.SerializeObject(clientsCollection, Formatting.Indented);
                stream.Write(json);
            }
        }

        public void AddNewClient(Client newClient)
        {
            clients.Add(newClient);
            InFile();
        }
        public void DeleteClient(Client clientToDelete)
        {
            clients.Remove(clientToDelete);
            InFile();
        }
    }
}
