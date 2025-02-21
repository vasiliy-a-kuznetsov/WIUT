namespace WIUT.DAL
{

    public class Course
    {
        private string _name;
        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty");
                _name = value;
            }
        }

        public Course()
        {

        }

        public Course(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}