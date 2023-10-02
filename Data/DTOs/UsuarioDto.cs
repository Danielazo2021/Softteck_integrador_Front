using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UsuarioDto  //actualizar
    {
        public int? Id { get; set; }=0;
        public string Nombre { get; set; }
        public string UserName { get; set; }    
        public string Email { get; set; }
        public int dni { get; set; }
        public Tipo tipo { get; set; }
        public string contrasena { get; set; }
    }
}
