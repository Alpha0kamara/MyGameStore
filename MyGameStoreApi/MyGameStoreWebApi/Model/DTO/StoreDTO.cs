using System.Collections.Generic;

namespace MyGameStoreWebApi.Model.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public bool IsFranchiseStore { get; set; }
        public List<PersonDTO> Persons { get; set; }
    }
}
