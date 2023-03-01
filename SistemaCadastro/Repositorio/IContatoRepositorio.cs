﻿using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarporId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
