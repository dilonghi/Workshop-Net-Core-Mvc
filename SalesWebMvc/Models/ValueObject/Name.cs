namespace SalesWebMvc.Models.ValueObject
{
    public class Name
    {
        public Name(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public Name()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
