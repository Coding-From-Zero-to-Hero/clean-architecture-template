using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Data;
using Application.Abstractions.Repositories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users;

internal class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task Add(User entity, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == id, cancellationToken); 
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
