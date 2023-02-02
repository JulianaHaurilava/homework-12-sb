using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            File.AppendAllText(fileName, newClient.GetJson());
        }

        private void OutOfFile()
        {
            if (File.Exists(fileName))
            {
                string json;
                using (StreamReader stream = new StreamReader(fileName, true))
                {
                    json = stream.ReadToEnd();
                }
                //string a = JObject.Parse(json).ToString();
                //while (JObject.Parse(json).ToString() != null)
                //{

                //}

            }
            //string json = File.ReadAllText("telegram.json");

            //Console.WriteLine(JObject.Parse(json)["ok"].ToString());

            //var messages = JObject.Parse(json)["result"].ToArray();
            //Console.WriteLine();
            //foreach (var item in messages)
            //{
            //    Console.WriteLine(item["message"]["message_id"].ToString());
            //    Console.WriteLine(item["message"]["text"].ToString());
            //    Console.WriteLine(item["message"]["chat"]["username"].ToString());
            //    Console.WriteLine();
            //}

            //Console.ReadLine(); Console.Clear();
        }

        private void InFile()
        {
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                foreach (Client client in clients)
                {
                    stream.Write(fileName, client.GetJson());
                }
            }
        }

        public void AddNewClient(Client newClient)
        {
            clients.Add(newClient);
            NewClientInFile(newClient);
        }
        public void DeleteClient(Client clientToDelete)
        {
            clients.Remove(clientToDelete);
            InFile();
        }
    }
}
