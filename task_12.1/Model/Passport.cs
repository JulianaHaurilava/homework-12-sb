namespace task_12._1
{
    public class Passport
    {
        public string Series { get; private set; }
        public string Number { get; private set; }
        public Passport(string series, string number)
        {
            Series = series;
            Number = number;
        }

        public override string ToString()
        {
            return Series + Number;
        }
    }
}
