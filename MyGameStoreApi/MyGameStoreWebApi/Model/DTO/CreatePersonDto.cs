namespace MyGameStoreWebApi.Model.DTO
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public int? StoreId { get; set; }
    }
}
