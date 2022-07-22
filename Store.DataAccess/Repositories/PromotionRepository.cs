using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories
{
    public class PromotionRepository: GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(AppDbContext context):base(context)
        {

        }
    }
}
