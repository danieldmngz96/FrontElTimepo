namespace FrontElTimepo.Models
{
    public class UsuariosDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } // Lista de roles del usuario
    }
}
