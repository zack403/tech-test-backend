﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechTestBackend.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository Payments { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
