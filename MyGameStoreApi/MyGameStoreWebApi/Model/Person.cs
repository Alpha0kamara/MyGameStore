using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameStoreWebApi.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender {  get; set; }
        public string Email { get; set; }
        //fk naar store
        public int? StoreId { get; set; }

        //navigations properties
        public Store Store { get; set; }


    }
}
