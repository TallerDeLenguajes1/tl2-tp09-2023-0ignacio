using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp09_2023_0ignacio.Models;

namespace tl2_tp09_2023_0ignacio.Repositories
{
    public interface IUsuarioRepository
    {
        public void Create(Usuario usuario);
        public void Update(int id, Usuario usuario);
        public List<Usuario> GetAll();
        public Usuario GetById(int idUsuario);
        public void Delete(int idUsuario);
    }
}