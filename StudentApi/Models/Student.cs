namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }

        public Address? HomeResidence { get; set; } = null;

        public Student()
        {   
        }

        public Student(string name, string firstName) : this()
        {
            Name = name;
            FirstName = firstName;
        }

        public Student(string name, string firstName, string street, string zipCode, string city) : this(name, firstName)
        {
            HomeResidence = new Address(street, zipCode, city);
        }
    }
}
