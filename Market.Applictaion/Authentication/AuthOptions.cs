using System.Collections.Generic;

namespace Market.Applictaion.Authentication
{
    public class AuthOptions
    {
        public string Secret { get; set; }
        public List<UserIdentity> Users { get; set; }
    }

    public class UserIdentity
    { 
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
