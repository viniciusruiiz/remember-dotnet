using Remember.Domain.Arguments;

namespace Remember.Domain.Interface.Service
{
    public interface IAuthService
    {
        BaseResponse SignUp(SignUpRequest user);

        BaseResponse SignIn(SignInRequest credentials);
    }
}
