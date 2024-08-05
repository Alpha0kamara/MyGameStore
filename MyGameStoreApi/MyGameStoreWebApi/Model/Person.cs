using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameStoreWebApi.Model
{
    [Table("tblPeople",Schema ="Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(70) , Required]
        public string LastName { get; set; }
        public int Gender {  get; set; }
        [MaxLength(100),Column("EmailAddress"), EmailAddress]
        public string Email { get; set; }
        //fk naar store
        public int? StoreId { get; set; }

        //navigations properties
        public Store Store { get; set; }


    }
}
