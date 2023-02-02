namespace task_12._1
{
    public class FullName
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }

        public FullName(string surname, string name,
            string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
