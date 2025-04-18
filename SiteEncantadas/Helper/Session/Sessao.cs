﻿using Newtonsoft.Json;
using SiteEncantadas.Models.Entities;
using SiteEncantadas.Models.Entities.Reserva;

namespace SiteEncantadas.Helper.Session
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContext_;
        public Usuario UsuarioLogado { get; set; }
        public Sessao(IHttpContextAccessor httpContext_)
        {
            this.httpContext_ = httpContext_;
        }

        public Usuario BuscarSessaoUsuario()
        {
            string sessaoUsuario = httpContext_.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            Usuario usuarioLogado = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
            UsuarioLogado = usuarioLogado;
            return usuarioLogado;
        }

        public void CriarSessaoUsuario(Usuario usuario)
        {
            usuario.ListaReservas = [];
            
            string usuarioJson = JsonConvert.SerializeObject(usuario);
            httpContext_.HttpContext.Session.SetString("sessaoUsuarioLogado", usuarioJson);
        }

        public void RemoverSessaoUsuario()
        {
            httpContext_.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        public void AtualizarSessao(Usuario usuario)
        {
            UsuarioLogado = usuario;
            string usuarioJson = JsonConvert.SerializeObject(usuario);
            httpContext_.HttpContext.Session.SetString("sessaoUsuarioLogado", usuarioJson);
        }
    }
}
