using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.UseCases.Commands
{
    public class AuthenticateUserCommand : IRequest<ResponseModel<string>>
    {
        public AuthenticateUserCommand(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; set; }

        public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, ResponseModel<string>>
        {
            private readonly IAuthenticationService _authService;

            public AuthenticateUserCommandHandler(IAuthenticationService authService)
            {
                _authService = authService;
            }

            public async Task<ResponseModel<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
            {
                var commandResult = _authService.Authenticate(request.User);
                if (commandResult == null)
                {
                    return await Task.FromResult(ResponseModel<string>.Create(ResponseCode.InvalidUser));
                }
                return await Task.FromResult(ResponseModel<string>.Create(ResponseCode.Success, commandResult));
            }
        }
    }
}
