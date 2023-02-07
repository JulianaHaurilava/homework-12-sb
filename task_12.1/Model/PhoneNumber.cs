using Newtonsoft.Json;

namespace task_12._1
{
    public class PhoneNumber
    {
        public string Number { get; private set; }
        public string СityCode { get; private set; }
        public string СountryCode { get; private set; }

        [JsonConstructor]
        public PhoneNumber(string countryCode, string cityCode,
            string number)
        {
            СountryCode = countryCode;
            СityCode = cityCode;
            Number = number;
        }

        public PhoneNumber(string phoneNumber)
        {
            Number = phoneNumber.Substring(phoneNumber.Length - 7);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 7);
            СityCode = phoneNumber.Substring(phoneNumber.Length - 2);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 2);
            СountryCode = phoneNumber.Substring(1);
        }

        /// <summary>
        /// Возвращает строку, содержащую номер телефона без спец символов
        /// </summary>
        /// <returns></returns>
        public string ReturnSimpleNumber()
        {
            return "+" + СountryCode + СityCode + Number;
        }

        public override string ToString()
        {
            string outCountryCode;
            switch (СountryCode.Length)
            {
                case 5:
                    outCountryCode = string.Format("{0:+#-###}",
                        int.Parse(СountryCode));
                    break;
                default:
                    outCountryCode = СountryCode;
                    break;
            }
            return "+" + outCountryCode + " (" + СityCode + ") " +
                string.Format("{0:###-##-##}", int.Parse(Number));
        }

        public static bool operator ==(PhoneNumber phn_1, PhoneNumber phn_2)
        {
            return phn_1.СountryCode == phn_2.СountryCode &&
                phn_1.СityCode == phn_2.СityCode &&
                phn_1.Number == phn_2.Number;
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
