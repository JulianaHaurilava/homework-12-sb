using System;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace task_12._1
{
    public class Client : INotifyPropertyChanged
    {
        private FullName fullName;
        public FullName FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private PhoneNumber phoneNumber;
        public PhoneNumber PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private Passport passport;
        public Passport Passport
        {
            get => passport;
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }
        public Client(string surname, string name, string patronymic,
            string phoneNumber, string passportSeries, string passportNumber)
        {
            fullName = new FullName(surname, name, patronymic);
            this.phoneNumber = new PhoneNumber(phoneNumber);
            Passport = new Passport(passportSeries, passportNumber);
        }

        [JsonConstructor]
        public Client(FullName fullName, PhoneNumber phoneNumber, Passport passport)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Passport = passport;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public JObject GetJson()
        {
            JObject jClient = new JObject();

            JObject jFullName = new JObject();
            jFullName["Surname"] = fullName.Surname;
            jFullName["Name"] = fullName.Name;
            jFullName["Patronymic"] = fullName.Patronymic;

            jClient["FullName"] = jFullName;

            JObject jPhoneNumber = new JObject();
            jPhoneNumber["CountryCode"] = phoneNumber.СountryCode;
            jPhoneNumber["CityCode"] = phoneNumber.СityCode;
            jPhoneNumber["Number"] = phoneNumber.Number;

            jClient["PhoneNumber"] = jPhoneNumber;

            JObject jPassport = new JObject();
            jPassport["Series"] = passport.Series;
            jPassport["Number"] = passport.Number;

            jClient["Passport"] = jPassport;

            return jClient;
        }
    }
}

