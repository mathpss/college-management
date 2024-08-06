using college_management.Dados.Repositorios.Interfaces;
using college_management.Modelos;

namespace college_management.Dados.Repositorios;

public class RepositorioUsuarios : Repositorio<Usuario>, IRepositorioUsuarios
{
    public Usuario ObterPorLogin(string login)
    {
        return _baseDeDados.FirstOrDefault(u => u.Login == login);
    }

    public override async Task Adicionar(Usuario usuario)
    {
        var modeloExistente = ObterPorLogin(usuario.Login);

        if (modeloExistente is not null) 
            return;
        
        _baseDeDados.Add(usuario);

        await Task.Run(Dispose);
    }
}