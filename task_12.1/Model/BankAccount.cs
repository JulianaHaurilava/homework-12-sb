namespace task_12._1.Model
{
    public class BankAccount
    {
        public int Money { get; set; }


        public BankAccount(int money)
        {
            Money = money;
        }

        public BankAccount()
        {
            Money = default;
        }

        public override string ToString()
        {
            return Money.ToString();
        }
    }
}
