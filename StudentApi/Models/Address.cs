using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public Address() {
            this.Id = Guid.NewGuid().ToString();
        }
        public Address(string street, string zipCode, string city) : this()
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

    }
}