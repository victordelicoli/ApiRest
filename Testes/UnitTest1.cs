using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiRest.Controllers;
using Entidades;
using Repositorio;

namespace Testes
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void TesteConsultaComSucesso()
        {
            var controller = new LivrosController();
            var resposta = controller.Obter();

            Assert.AreEqual(true, resposta.IsSuccessStatusCode);
        }
        [TestMethod]
        public void TesteInserirComSucesso()
        {
            var controller = new LivrosController();
            var resposta = controller.Inserir(new Livro() {
                Autor = "Autor 1",
                Titulo = "Titulo 1"
            });

            Assert.AreEqual(true, resposta.IsSuccessStatusCode);
        }
        [TestMethod]
        public void TesteInserirErroSemTitulo()
        {
            var controller = new LivrosController();
            var resposta = controller.Inserir(new Livro()
            {
                Autor = "Autor 1",
            });

            Assert.AreEqual(false, resposta.IsSuccessStatusCode);
        }
        [TestMethod]
        public void TesteInserirErroSemAutor()
        {
            var controller = new LivrosController();
            var resposta = controller.Inserir(new Livro()
            {
                Titulo = "Titulo 1",
            });

            Assert.AreEqual(false, resposta.IsSuccessStatusCode);
        }
    }
}
