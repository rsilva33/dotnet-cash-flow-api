﻿namespace CashFlow.Domain.Abstractions.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();
}
