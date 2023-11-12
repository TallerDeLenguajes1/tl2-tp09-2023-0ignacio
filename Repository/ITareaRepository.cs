using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp09_2023_0ignacio.Models;

namespace tl2_tp09_2023_0ignacio.Repositories
{
    public interface ITareaRepository
    {
        public void Create(int idTablero, Tarea tarea);
        public void Update(int idTarea, Tarea tarea);
        public void Assign(int idUsuario, int idTarea);
        public Tarea GetById(int idTarea);
        public List<Tarea> GetAllByUsuario(int idUsuario);
        public List<Tarea> GetAllByTablero(int idTablero);
        public void Delete(int idTarea);
    }
}