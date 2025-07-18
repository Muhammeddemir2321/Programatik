﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Planora.Application.Services.Repositories;

public interface IOperationClaimRepository: IAsyncRepository<OperationClaim>, IRepository<OperationClaim>,IDynamicRepository<OperationClaim> { }