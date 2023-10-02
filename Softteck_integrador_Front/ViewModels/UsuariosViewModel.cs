using Data.DTOs;

namespace UmsaSofttekFront.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public string Contrasena { get; set; }
        public int Tipo { get; set; }

            


        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Id = usuario.Id;
            usuariosViewModel.FirstName = usuario.Nombre;
            usuariosViewModel.UserName = usuario.UserName;
            usuariosViewModel.Email = usuario.Email;
            usuariosViewModel.Dni = usuario.Dni;
            usuariosViewModel.Tipo = usuario.Tipo;
            usuariosViewModel.Contrasena = usuario.Contrasena;


            return usuariosViewModel;
        }
    }
}
