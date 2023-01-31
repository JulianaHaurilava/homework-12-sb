namespace task_12._1
{
    public struct PhoneNumber
    {
        string countryCode;
        string cityCode;
        string number;

        public PhoneNumber(string phoneNumber)
        {
            number = phoneNumber.Substring(phoneNumber.Length - 7);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 7);
            cityCode = phoneNumber.Substring(phoneNumber.Length - 2);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 2);
            countryCode = phoneNumber.Substring(1);
        }

        /// <summary>
        /// Возвращает строку, содержащую номер телефона без спец символов
        /// </summary>
        /// <returns></returns>
        public string ReturnSimpleNumber()
        {
            return "+" + countryCode + cityCode + number;
        }

        public override string ToString()
        {
            string outCountryCode;
            switch (countryCode.Length)
            {
                case 5:
                    outCountryCode = string.Format("{0:+#-###}",
                        int.Parse(countryCode));
                    break;
                default:
                    outCountryCode = countryCode;
                    break;
            }
            return "+" + outCountryCode + " (" + cityCode + ") " +
                string.Format("{0:###-##-##}", int.Parse(number));
        }

        public static bool operator ==(PhoneNumber phn_1, PhoneNumber phn_2)
        {
            return phn_1.countryCode == phn_2.countryCode &&
                phn_1.cityCode == phn_2.cityCode &&
                phn_1.number == phn_2.number;
        }

        public static bool operator !=(PhoneNumber phn_1, PhoneNumber phn_2)
        {
            return !(phn_1 == phn_2);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) ? true : ReferenceEquals(obj, null) ? false : throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
