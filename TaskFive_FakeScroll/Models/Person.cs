namespace TaskFive_FakeScroll.Models
{
    public class Person
    {
        public Person(string name, string lastName, string middleName, string address, string phone)
        {
            Id=Guid.NewGuid();
            Name=name;
            LastName=lastName;
            MiddleName=middleName;
            Address=address;
            Phone=phone;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
