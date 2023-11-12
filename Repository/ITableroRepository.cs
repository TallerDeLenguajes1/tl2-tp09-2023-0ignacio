using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp09_2023_0ignacio.Models;

namespace tl2_tp09_2023_0ignacio.Repositories
{
    public interface ITableroRepository
    {
        public void Create(Tablero tablero);
        public void Update(int idTablero, Tablero tablero);
        public List<Tablero> GetAll();
        public Tablero GetById(int idTablero);
        public List<Tablero> GetByUsuario(int idUsuario);
        public void Delete(int idTablero);
    }
}