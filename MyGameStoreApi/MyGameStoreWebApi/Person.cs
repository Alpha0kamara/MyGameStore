namespace MyGameStoreWebApi
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Sex Gender { get; set; }
    }
    public enum Sex
    {
       male = 0,
       female = 1,
    }
}
