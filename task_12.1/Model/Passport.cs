namespace task_12._1
{
    public struct Passport
    {
        string series;
        string number;
        public Passport(string series, string number)
        {
            this.series = series;
            this.number = number;
        }

        public override string ToString()
        {
            return series + number;
        }
    }
}
