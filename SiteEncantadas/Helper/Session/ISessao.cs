using SiteEncantadas.Models.Entities;

namespace SiteEncantadas.Helper.Session
{
    public interface ISessao
    {
        public void CriarSessaoUsuario(Usuario usuario);

        public void RemoverSessaoUsuario();

        public Usuario BuscarSessaoUsuario();
    }
}
