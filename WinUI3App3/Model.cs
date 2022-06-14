namespace WinUI3App3
{
    public class Customer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }

        public Customer(int id, string firstName, string lastName, string address, string postalcode, string companyName, string department)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PostalCode = postalcode;
            this.CompanyName = companyName;
            this.Department = department;
        }

    }
}
