using System;
using System.ComponentModel;
using System.IO;

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


        public Client()
        {
            FullName = new FullName();
            PhoneNumber = new PhoneNumber();
            Passport = new Passport();
        }
        public Client(string surname, string name, string patronymic,
            string phoneNumber, string passportSeries, string passportNumber)
        {
            fullName = new FullName(surname, name, patronymic);
            this.phoneNumber = new PhoneNumber(phoneNumber);
            Passport = new Passport(passportSeries, passportNumber);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

