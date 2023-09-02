using ApiImoveis.DataBase;
using ApiImoveis.Global;
using ApiImoveis.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ApiImoveis.Global.Config;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiImoveis.Controllers
{
    [ApiController]
    [Route("api/imoveis")]
    public class ImoveisController : Controller
    {

        [HttpGet]
        [Route("GetAll")]

        public JsonResult GetAll(string token)
        {
            Result result = new Result();
            Security security = new Security();
            try
            {
                if (security.ValidateToken(token))
                {
                    List<Imoveis> imoveis = new List<Imoveis>();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetAll();

                    if (imoveis.Count > 0)
                    {
                        Log.Save("Dados pegos com sucesso");
                        result.data = JsonConvert.SerializeObject(imoveis);
                        result.success = true;



                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                        result.errorMessage = ErrorCode.JobNotFoundError.ToString();
                    }
                }
                else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }

            return new JsonResult(result);
        }


        [HttpGet]
        [Route("Get")]
        public JsonResult Get(int id, string token)
        {
            Result result = new Result();
            Security security = new Security();

            try
            {
                if (security.ValidateToken(token))
                {
                    Imoveis imoveis = new Imoveis();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.Get(id);

                    if (imoveis != null && imoveis.id > 0)
                    {

                        result.data = JsonConvert.SerializeObject(imoveis);
                        result.success = true;
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                        result.errorMessage = ErrorCode.JobNotFoundError.ToString();
                    }
                }
                else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnknownError);
                result.errorMessage = ErrorCode.UnknownError.ToString() + " - " + ex.Message;

            }

            return new JsonResult(result);

        }

        [HttpGet]
        [Route("GetWithFilter")]
        public JsonResult GetWithFilter(string token, string filter = null, string search = null)
        {
            Result result = new Result();
            Security security = new Security();
            try
            {
                if (security.ValidateToken(token))
                {
                    List<Imoveis> imoveis = new List<Imoveis>();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetWithFilter(filter, search);
                    if (imoveis != null && imoveis.Count > 0)
                    {
                        result.data = JsonConvert.SerializeObject(imoveis);
                        result.success = true;
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                        result.errorMessage = ErrorCode.JobNotFoundError.ToString();
                    }
                }
                else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }


            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, data = ex.Message });
            }
            return new JsonResult(result);
        }


        [HttpPost]
        [Route("Add")]

        public JsonResult Add(RequestData data)
        {
            Result result = new Result();
         
            Security security = new Security();
            try
            {
                if (security.ValidateToken(data.token))
                {
                    DBConsulta consulta = new DBConsulta();

                    data.imoveis.id = consulta.GetAll().Count + 1;
                    bool a = consulta.Add(data.imoveis);

                    if (a)
                    {
                        Log.Save("Dados adicionados com sucesso");
                        result.success = true;
                    }
                    else
                    {
                        result.success = false;
                    }
                }
                else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }
            return new JsonResult(result);
        }


        [HttpPut]
        [Route("Update")]

        public JsonResult Update(RequestData data)
        {

            Result result = new Result();
            Security security = new Security();
            try
            {
                if (security.ValidateToken(data.token))
                {
                    DBConsulta consulta = new DBConsulta();
                    bool resultado = consulta.Update(data.imoveis);
                    if (resultado)
                    {
                        Log.Save("Dados alterados com sucesso");
                        result.success = true;
                    }
                    else
                    {
                        result.success = false;
                        result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                        result.errorMessage = ErrorCode.JobNotFoundError.ToString();
                    }

                }
                else
                {
                    result.success = false;
                    result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + "Token invalido";
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }
            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("Delete")]

        public JsonResult Delete(int id, string token)
        {
            Security security = new Security();

            try
            {
                if (security.ValidateToken(token))
                {
                    DBConsulta consulta = new DBConsulta();
                    bool result = consulta.Delete(id);
                    if (result)
                    {
                        Log.Save("Dados deletados com sucesso");
                        return new JsonResult(new { success = true, msg = "imovel " + id + " excluido com sucesso" });
                    }
                    else
                    {
                        return new JsonResult(new { success = true, msg = "Imovel não encontrado " });
                    }
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "token invalido" });
                }
            }

            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}

