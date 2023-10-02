using Data.DTOs;

namespace UmsaSofttekFront.ViewModels
{
    public class UsuariosViewModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int dni { get; set; }
        public string contrasena { get; set; }
        public Tipo tipo { get; set; }

            


        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Id = usuario.Id;
            usuariosViewModel.FirstName = usuario.Nombre;
            usuariosViewModel.UserName = usuario.UserName;
            usuariosViewModel.Email = usuario.Email;
            usuariosViewModel.dni = usuario.dni;
            usuariosViewModel.tipo = usuario.tipo;
            usuariosViewModel.contrasena = usuario.contrasena;


            return usuariosViewModel;
        }
    }
}
