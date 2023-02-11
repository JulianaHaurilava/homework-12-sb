namespace task_12._1.Model
{
    public class FullName
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public FullName(string surname, string name,
            string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        public FullName()
        {
            Surname = default;
            Name = default;
            Patronymic = default;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
