using Microsoft.AspNetCore.Identity;

namespace CrossCutting.User
{
    public class Usuario : IdentityUser
    {
        public byte[] PhotoFile { get; set; }
        public string ImageName { get; set; }
        public string ProfessorId { get; set; }
        public string RoleName { get; set; }

        public decimal? Pontuacao { get; set; }
    }
}
