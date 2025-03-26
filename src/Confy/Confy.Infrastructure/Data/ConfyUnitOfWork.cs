﻿using Confy.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Confy.Infrastructure.Data;
public class ConfyUnitOfWork(ConfyDbContext dbContext) : IUnitOfWork
{
	private IDbContextTransaction? _currentTransaction;

	public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
	{
		_currentTransaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
		return _currentTransaction.GetDbTransaction();
	}

	public async Task CommitAsync(CancellationToken cancellationToken = default)
	{
		if (_currentTransaction != null)
		{
			await SaveChangesAsync(cancellationToken);
			await _currentTransaction.CommitAsync(cancellationToken);
			await _currentTransaction.DisposeAsync();
			_currentTransaction = null;
		}
	}

	public async Task RollbackAsync(CancellationToken cancellationToken = default)
	{
		if (_currentTransaction != null)
		{
			await _currentTransaction.RollbackAsync(cancellationToken);
			await _currentTransaction.DisposeAsync();
			_currentTransaction = null;
		}
	}

	public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return await dbContext.SaveChangesAsync(cancellationToken);
	}
}
