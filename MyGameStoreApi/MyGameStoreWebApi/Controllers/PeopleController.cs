using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameStoreWebApi.DAL;
using MyGameStoreWebApi.Model;
using MyGameStoreWebApi.Model.DTO;
using System.Linq;

namespace MyGameStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private GameStoreContext _gameStoreContext;
        public PeopleController(GameStoreContext gameStoreContext)
        {
            _gameStoreContext = gameStoreContext;
        }
        #region Person Crud operations
        //ophalen van mensen
        [HttpGet]
        public IActionResult GetPeople()
        {
            var result = _gameStoreContext.Persons;
            if (result.Any() == false)
            {
                return NotFound(new { message = "The person list is empty"});
            }
            return Ok(result);
        }
        //ophalen van een person volgens id
        [HttpGet("{id}")]
        public IActionResult GetPeopleId(int id)
        {
            var result = _gameStoreContext.Persons.Where(p => p.Id == id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // persoon toevoegen
        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreatePersonDto personDto)
        {
            var person = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Gender = personDto.Gender,
                Email = personDto.Email,
                StoreId = personDto.StoreId

            };
            _gameStoreContext.Persons.Add(person);
            _gameStoreContext.SaveChanges();
            return Ok();
        }

        // aanpassen van een persoongegevens
        [HttpPut]
        public IActionResult UpdatePeople([FromBody] Person updatedPerson)
        {
            var result = _gameStoreContext.Persons.Where(p => p.Id == updatedPerson.Id).FirstOrDefault();
            if (result == null)
            {
                return NotFound(new { message = "Person with this id is not found" });
            }
            _gameStoreContext.Update(updatedPerson);
            _gameStoreContext.SaveChanges();
            return Ok(result);
        }

        // persoon verwijderen
        // mensen alleen verwijderen als de juiste api key mee is gegeven 
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id,[FromHeader(Name = "X-AccesKey")] string key)
        {
            //checken als de juiste api key is meegegeven
            var apiK = "123456789";
            if(string.IsNullOrEmpty(key) || key != apiK)
            {
                return Unauthorized(new { message = "Invalid or missing API key" });
            }
            var person = _gameStoreContext.Persons.Where(p => p.Id == id).FirstOrDefault();

            if (person != null)
            {
                Person person1 = new() { Id = id };
                _gameStoreContext.Remove(person1);
                _gameStoreContext.SaveChanges();
                return NoContent();
            }
            return NotFound(new { message = "person not found" });
        }
        #endregion
       
    }
}
