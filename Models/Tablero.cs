using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp09_2023_0ignacio.Models
{
    public class Tablero
    {
        private int id;
        private int idUsuarioPropietario;
        private string nombre;
        private string desc;

        public int Id { get => id; set => id = value; }
        public int IdUsuarioPropietario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}