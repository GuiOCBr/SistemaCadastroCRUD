using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorio;

namespace SistemaCadastro.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
           List<ContatoModel> contatos =  _contatoRepositorio.BuscarTodos();
           return View(contatos);
        }
    

        public IActionResult Criar()
        {
            return View();
        }


        public IActionResult Editar(int id)
        {
           ContatoModel contato =  _contatoRepositorio.ListarporId(id);
            return View(contato);
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarporId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado =  _contatoRepositorio.Apagar(id);
                if (apagado) 
                { 
                  TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; 
                }
                else
                {
                  TempData["MensagemErro"] = "Ops, sem sucesso a exclusão!";
                }
               return RedirectToAction("index");
            }
            
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, sem sucesso a exclusão erro em {erro.Message}!";
                return RedirectToAction("index");

            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato criado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, houve erro do tipo {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }

            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, houve erro do tipo {erro.Message}!";
                return RedirectToAction("Index");

            }



           
        }
    }
}
