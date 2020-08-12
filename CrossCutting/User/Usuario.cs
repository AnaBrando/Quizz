using Microsoft.AspNetCore.Identity;

namespace CrossCutting.User
{
    public class Usuario : IdentityUser
    {
        public string ImageName { get; set; }
        public string ProfessorId { get; set; }
        public string RoleName { get; set; }

        public decimal? Pontuacao { get; set; }
    }
}
