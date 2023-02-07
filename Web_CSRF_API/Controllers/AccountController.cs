using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_CSRF_API.Models;

namespace Web_CSRF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AutoValidateAntiforgeryToken]
    [ValidateAntiForgeryToken]
    public class AccountController : ControllerBase
    {
        private ResponseModel responseModel;

        [HttpGet("GetCustomer")]
        //[ValidateAntiForgeryToken]
        public IActionResult Get()
        {
            responseModel = new ResponseModel();
            responseModel.IsSuccess = true;
            responseModel.Content = "GetCustomer Method";
            return Ok(responseModel);
        }

        [HttpPost("PostCustomer")]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] string value)
        {
            responseModel = new ResponseModel();
            responseModel.IsSuccess = true;
            responseModel.Content = "PostCustomer Method";
            return Ok(responseModel);
        }

        [HttpGet("GetDetails")]
        [IgnoreAntiforgeryToken]
        public IActionResult GetDetails()
        {
            responseModel = new ResponseModel();
            responseModel.IsSuccess = true;
            responseModel.Content = "GetDetails Method";
            return Ok(responseModel);
        }
    }
}
