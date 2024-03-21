﻿
using EduPortal.Application.Interfaces.Repositories;
using EduPortal.Domain.Abstractions;
using EduPortal.Domain.Entities;
using EduPortal.Persistence.context;
using EduPortal.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Persistence.Repositories
{
    public class SubsCorporateRepository : GenericRepository<SubsCorporate, int>, ISubsCorporateRepository
    { 
        private readonly IGenericRepository<SubsCorporate, int> _genericRepository;

        public SubsCorporateRepository(AppDbContext context, IGenericRepository<SubsCorporate, int> genericRepository) : base(context)
        {
            _genericRepository = genericRepository;
        }


        public async Task CreateCorporateSubscription(SubsCorporate subsCorporate)
        {
            await _genericRepository.AddAsync(subsCorporate);
        }
    }
}