using CashFlow.Domain.Abstractions.Security.Cryptograpy;

namespace CashFlow.Application.UseCases.Expenses.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;

    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        user.Password = _passwordEncripter.Encrypt(user.Password);

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
