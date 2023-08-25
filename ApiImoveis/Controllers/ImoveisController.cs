using ApiImoveis.DataBase;
using ApiImoveis.Global;
using ApiImoveis.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiImoveis.Controllers
{
    [ApiController]
    [Route("api/imoveis")]
    public class ImoveisController : Controller
    {
       
            [HttpGet]
            [Route("GetAll")]

            public JsonResult GetAll()
            {

                try
                {
                    List<Imoveis> imoveis = new List<Imoveis>();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetAll();

                    if (imoveis.Count > 0)
                    {
                        Log.Save("Dados pegos com sucesso");
                        return new JsonResult(new { success = true, imovel = imoveis });

                    }
                    else
                    {
                        return new JsonResult(new { success = true, imovel = "0 imoveis na lista" });
                    }

                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, msg = ex.Message });
                }
            }

            [HttpGet]
            [Route("GetCidade")]

            public JsonResult GetCidade(string cidade)
            {

                try
                {
                    Imoveis imoveis = new Imoveis();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetCidade(cidade);
                    Log.Save("Dados pegos com sucesso com a cidade");
                    return new JsonResult(new { success = true, data = imoveis });

                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, data = ex.Message });
                }
            }

            [HttpGet]
            [Route("GetBairro")]

            public JsonResult GetBairro(string bairro)
            {

                try
                {
                    Imoveis imoveis = new Imoveis();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetBairro(bairro);
                    Log.Save("Dados pegos com sucesso com o bairro");
                    return new JsonResult(new { success = true, data = imoveis });

                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, data = ex.Message });
                }
            }

            [HttpGet]
            [Route("GetTipo")]

            public JsonResult GetTipo(string tipo)
            {

                try
                {
                    Imoveis imoveis = new Imoveis();
                    DBConsulta consulta = new DBConsulta();
                    imoveis = consulta.GetTipo(tipo);
                    Log.Save("Dados pegos com sucesso com o tipo");
                    return new JsonResult(new { success = true, data = imoveis });

                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, data = ex.Message });
                }
            }

            [HttpPost]
            [Route("Add")]

            public JsonResult Add(Imoveis imoveis)
            {
                try
                {
                    DBConsulta consulta = new DBConsulta();
                    bool a = consulta.Add(imoveis);
                    Log.Save("Dados adicionados com sucesso");
                    return new JsonResult(new { success = true, msg = "imovel " + imoveis.id + "guardado com sucesso"  });
                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, msg = ex.Message });
                }
            }


            [HttpPut]
            [Route("Update")]

            public JsonResult Update(Imoveis imoveis)
            {


                try
                {
                    DBConsulta consulta = new DBConsulta();
                    bool result = consulta.Update(imoveis);
                    if (result)
                    {
                        Log.Save("Dados alterados com sucesso");
                        return new JsonResult(new { success = true, msg = "imovel " + imoveis.id + " alterada com sucesso" });
                    }
                    else
                    {
                        return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                    }

                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, msg = ex.Message });
                }
            }

            [HttpDelete]
            [Route("Delete")]

            public JsonResult Delete(int id)
            {


                try
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


                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, msg = ex.Message });
                }
            }
        }
    }

