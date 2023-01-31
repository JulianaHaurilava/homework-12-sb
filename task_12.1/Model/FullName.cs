namespace task_12._1
{
    public struct FullName
    {
        string surname;
        string name;
        string patronymic;

        public FullName(string surname, string name,
            string patronymic)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
        }

        public override string ToString()
        {
            return surname + " " + name + " " + patronymic;
        }
    }
}
