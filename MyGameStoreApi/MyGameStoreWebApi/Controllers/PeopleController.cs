using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGameStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static List<Person> _people = new List<Person>();
        static PeopleController()
        {
            Person alpha = new Person
            {
                Id = 1,
                Gender = Sex.male,
                FirstName = "Alpha",
                LastName = "Kamara"
            };
            Person ismail = new Person
            {
                Id = 2,
                Gender = Sex.male,
                FirstName = "Ismail",
                LastName = "Kamara"
            };
            _people.Add(alpha);
            _people.Add(ismail);

        }

        //ophalen van mensen
        [HttpGet]
        public IActionResult GetPeople()
        {
            return Ok(_people);
        }
        // mensen toevoegen
        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            _people.Add(person);
            return Ok(_people);
        }

        // aanpassen van mensen
        [HttpPut]
        public IActionResult UpdatePeople([FromBody] Person updatedPerson)
        {
            var person = _people.FirstOrDefault(p => p.Id == updatedPerson.Id);
            if (person == null)
            {
                return NotFound(new { message = "A Person with this Id is not found" });
            }
            //person properties update
            person.FirstName = updatedPerson.FirstName ?? person.FirstName;
            person.LastName = updatedPerson.LastName ?? person.LastName;
            person.Gender = updatedPerson.Gender;
            return Ok(_people);
        }

        // mensen verwijderen
        // mensen alleen verwijderen als de juiste api key mee is gegeven 
        [HttpDelete]
        public IActionResult DeletePerson(int id,[FromHeader(Name = "X-AccesKey")] string key)
        {
            //checken als de juiste api key is meegegeven
            var apiK = "123456789";
            if(string.IsNullOrEmpty(key) || key != apiK)
            {
                return Unauthorized(new { message = "Invalid or missing API key" });
            }
            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                _people.Remove(person);
                return NoContent();
            }
            return NotFound(new { message = "person not found" });
        }
        //opvragen van een persoon an de hand van de id
        [HttpGet("{id:int}")]
        public IActionResult GetPersonById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Id is required");
            }
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                return Ok(person);
            }
            return NotFound(new { message = "Person not found" });
        }

        //opvragen van person aan de hand van de lastname
        [Route ("{lastName}")]
        [HttpGet]
        public IActionResult GetPersonByLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return NoContent();
            }
            var person = _people.Where(p => p.LastName.ToLower() == lastName.ToLower()).ToList();
            if(person != null)
            {
                return Ok(person);
            }
            return NotFound(new { message = "Person not found" });
        }
    }
}
