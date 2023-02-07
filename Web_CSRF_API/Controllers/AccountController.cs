using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_CSRF_API.Models;

namespace Web_CSRF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AutoValidateAntiforgeryToken]
    public class AccountController : ControllerBase
    {
        private IAntiforgery _antiForgery;
        private ResponseModel responseModel;
        public AccountController(IAntiforgery antiForgery)
        {
            _antiForgery = antiForgery;
        }

        [HttpGet("GetCustomers")]
        [ValidateAntiForgeryToken]
        public IActionResult Get()
        {
            responseModel = new ResponseModel();
            responseModel.IsSuccess = true;
            responseModel.Content = "GetMethod";
            return Ok(responseModel);
        }

        [HttpPost("PostCustomer")]
        [ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] string value)
        {
            responseModel = new ResponseModel();
            responseModel.IsSuccess = true;
            responseModel.Content = "PostMethod";
            return Ok(responseModel);
        }
    }
}
