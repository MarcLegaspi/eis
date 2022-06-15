using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PositionRepository: RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(EisContext context): base(context)
        {
            
        }

        public async Task<IReadOnlyList<Position>> GetPositions() 
        {
            return await base.ListAll()
                .Include(m => m.Department)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }
    }
}