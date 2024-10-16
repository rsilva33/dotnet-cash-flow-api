﻿using CashFlow.Domain.Abstractions.Repositories.User;
using CashFlow.Domain.Abstractions.Security.Cryptograpy;
using CashFlow.Domain.Abstractions.Security.Tokens;

namespace CashFlow.Application.UseCases.Login.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncrypter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IUserReadOnlyRepository repository,
        IPasswordEncrypter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _passwordEncripter = passwordEncripter;
        _repository = repository;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
            throw new InvalidLoginException();

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if (passwordMatch is false)
            throw new InvalidLoginException();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
