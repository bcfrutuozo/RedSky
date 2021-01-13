using System.Collections.Generic;

namespace RedSky.Presentation.Web.Membership
{
    public class AuthenticationUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public int IdEmpresa { get; set; }

        public string Nome { get; set; }

        public bool Parametrizador { get; set; }

        public ICollection<AuthenticationRole> Roles { get; set; }
    }
}