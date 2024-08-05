using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameStoreWebApi.Model
{
    [Table("tblStores", Schema = "Store")]
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        [MaxLength(60),Required]
        public string Street { get; set; }
        [MaxLength(5),Required]
        public string Number { get; set; }
        [MaxLength(2)]
        public string Addition { get; set; }
        [MaxLength(6), Required]
        public string Zipcode { get; set; }
        [MaxLength(60), Column("Place")]
        public string City { get; set; }
        public bool IsFranchiseStore { get; set; }
        public List<Person> Persons { get; set; }
    }
}
 