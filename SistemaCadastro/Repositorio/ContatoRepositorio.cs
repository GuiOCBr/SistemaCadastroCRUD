
using SistemaCadastro.Data;
using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;  
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarporId(id);

            if (contatoDB == null) throw new Exception("Houve um erro na exclusão  do contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarporId(contato.Id);

            if(contatoDB == null)  throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contato.Email = contato.Email;
            contato.Celular= contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarporId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
