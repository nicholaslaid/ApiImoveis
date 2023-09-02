using ApiImoveis.Global;
using ApiImoveis.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiImoveis.Controllers
{
    [ApiController]
    [Route("api/imoveis")]
    public class AccessController : Controller
    {
        [HttpGet]
        [Route("GetToken")]

        public JsonResult GetToken(string key)
        {
            Result result = new Result();
            try
            {
               

                if (!string.IsNullOrEmpty(key))
                {
                   
                    Security security = new Security();
                    string token = security.GenerateToken(key);

                    if (!string.IsNullOrEmpty(token))
                    {

                        result.success = true;
                        result.data = token;
                    }
                    else
                    {
                        result.success = false;
                    }
                   
                }
                else
                {
                    result.success = false;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
            }
            return new JsonResult(result);
        }
    }
}
