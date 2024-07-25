using Microsoft.AspNetCore.Mvc;
using MyGameStoreWebApi.DAL;
using MyGameStoreWebApi.Model;
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
            var result = _storeContext.Stores;
            if (result.Any() == false)
            {
                return NoContent();
            }
            return Ok(result);
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
        public IActionResult UpdateStoreById([FromBody] Store UpdateStore)
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
