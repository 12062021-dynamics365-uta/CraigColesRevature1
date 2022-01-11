using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p0_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PProjectController : Controller //may need to be ControllerBase?
    {
        //if this is static, you COULD access it with 
        private readonly IDataManager dataManager;
        public PProjectController(IDataManager dm)
        {
            this._dataManager = dm;
        }
        
        //all of the methods in a controller are called ACTION METHODS,
        //to be accessable to outside world, they need to be public
        public IActionResult Index()
        {
            return View();
        }


        //this method will take the first and last names of the customer and check if that player exists in the DB
        //if not return 'not found'
        [HttpGet]
        [Route("Login/{}firstName}/{lastName}")]
        public IActionResult<Customer> Login(string firstName, string lastName)
        {
            //call the buisness (datamanger) layer to retrieve the customer, if it exists
            Customer c = this._dataManager.Login(firstName, lastName);
            return Ok(c);
        }
    }
}
