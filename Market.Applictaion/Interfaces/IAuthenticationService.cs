using Market.Applictaion.DTOs;

namespace Market.Applictaion.Interfaces
{
    public interface IAuthenticationService
    {
        public string Authenticate(UserDTO user);
    }
}
