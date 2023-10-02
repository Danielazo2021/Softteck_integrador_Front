using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UsuarioDto  //actualizar
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; }
        public string UserName { get; set; }    
        public string Email { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contrasena { get; set; }
    }
}
