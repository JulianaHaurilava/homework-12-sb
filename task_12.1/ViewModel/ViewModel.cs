using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace task_12._1
{
    public class ViewModel : ObservableCollection<Client>
    {
        private string fileName;
        public ViewModel()
        {
            fileName = "clients.json";
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
                foreach (Client client in this)
                {
                    if (client.PhoneNumber == phoneNumber)
                        return client;
                }
                return null;
            }
        }

        private void NewClientInFile(Client newClient)
        {
            string json = JsonConvert.SerializeObject(newClient);
            File.AppendAllText(fileName, json);
        }
        private void InFile()
        {
            //string json = JsonConvert.SerializeObject(this);
            //File.WriteAllText(fileName, json);

            using (StreamWriter stream = new StreamWriter(fileName))
            {
                string json = JsonConvert.SerializeObject(this);
                stream.Write(fileName, json);
            }
        }
        private void OutOfFile()
        {
            if (File.Exists(fileName))
            {
                List<Client> list;
                using (StreamReader stream = new StreamReader(fileName, true))
                {
                    string json = stream.ReadToEnd();
                    list = JsonConvert.DeserializeObject<List<Client>>(json);
                }
                foreach (Client client in list)
                {
                    Add(client);
                }
            }
        }

        public void AddNewClient(Client newClient)
        {
            Add(newClient);
            NewClientInFile(newClient);
        }
        public void DeleteClient(Client clientToDelete)
        {
            Remove(clientToDelete);
            InFile();
        }
    }
}
