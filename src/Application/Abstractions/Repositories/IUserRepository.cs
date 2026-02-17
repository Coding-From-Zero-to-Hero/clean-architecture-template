using System;
using System.Collections.Generic;
using System.Text;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task Add(User entity, CancellationToken cancellationToken);

    Task<User> GetById(Guid id, CancellationToken cancellationToken);

    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}
