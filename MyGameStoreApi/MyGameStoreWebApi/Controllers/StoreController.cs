using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameStoreWebApi.DAL;
using MyGameStoreWebApi.Model;
using MyGameStoreWebApi.Model.DTO;
using System.Linq;

namespace MyGameStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private GameStoreContext _storeContext;
        public StoreController(GameStoreContext storeContext) 
        {
            _storeContext = storeContext;
        }
        #region Store Crud operations
        //add an new store
        [HttpPost]
        public IActionResult CreateStore([FromBody] Store createStore)
        {
            _storeContext.Stores.Add(createStore);
            _storeContext.SaveChanges();
            return Ok();
        }
        //get all stores
        [HttpGet]
        public IActionResult GetAllStores()
        {
            var stores = _storeContext.Stores.AsNoTracking().Include(s => s.Persons).ToList();
            var storeDTos = stores.Select(s => new StoreDTO
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Number = s.Number,
                Addition = s.Addition,
                Zipcode = s.Zipcode,
                City = s.City,
                IsFranchiseStore = s.IsFranchiseStore,
                Persons = s.Persons.Select(p => new PersonDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Gender = p.Gender,
                    Email = p.Email
                }).ToList()
            }).ToList();

            if (!stores.Any())
            {
                return NoContent();
            }
            return Ok(stores);
        }
        //get an store by the id of the store
        [HttpGet("{id}")]
        public IActionResult GetStoreById(int id)
        {
            var result = _storeContext.Stores.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        //update an store
        [HttpPut]
        public IActionResult UpdateStoreById([FromBody] StoreDTO UpdateStore)
        {
            var result = _storeContext.Stores.Where(s => s.Id == UpdateStore.Id).FirstOrDefault();
            if(result == null)
            {
                return NotFound(new { message = "Person with this id is not found" });
            }
            _storeContext.Update(result);
            _storeContext.SaveChanges();
            return Ok();
        }
        // delete an store by id
        [HttpDelete]
        public IActionResult DeleteStoreById(int id)
        {
            var store = _storeContext.Stores.Where(s => s.Id == id).FirstOrDefault();
            if (store == null)
            {
                return NotFound(new { message = "A store with this id does not exists" });
            }
            _storeContext.Remove(store);
            _storeContext.SaveChanges();
            return Ok(store);
        }

        #endregion
    }
}
