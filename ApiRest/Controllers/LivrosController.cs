using ApiRest.Models;
using Entidades;
using Newtonsoft.Json;
using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    public class LivrosController : ApiController
    {
        GerenciadorDeLivros gerenciadorDeLivros;
        public LivrosController()
        {
            gerenciadorDeLivros = new GerenciadorDeLivros();
        }

        [HttpGet,ActionName("Obter")]
        public HttpResponseMessage Obter()
        {
            try
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(gerenciadorDeLivros.Consultar()),
                                            System.Text.Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }

        }

        [HttpPost, ActionName("Inserir")]
        public HttpResponseMessage Inserir(Livro livro)
        {
            try
            {
                if (gerenciadorDeLivros.Inserir(livro))
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("OK")
                    };
                }

                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("BAD REQUEST")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }

        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                gerenciadorDeLivros.Deletar(id);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("OK")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }
        }
    }
}
