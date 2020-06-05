using Microsoft.AspNetCore.Identity;

namespace CrossCutting.DTO
{
    public class UsuarioDTO : IdentityUser
    {
        public byte[] PhotoFile { get; set; }
        public string ImageName { get; set; }
        public string ProfessorId { get; set; }
        public string RoleName { get; set; }

        public decimal? Pontuacao { get; set; }

        public string Password { get; set; }
    }
}
