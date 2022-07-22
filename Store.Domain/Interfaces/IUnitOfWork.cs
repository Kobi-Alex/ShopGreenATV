using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IPromotionRepository Promotions { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        int Complete();
    }
}
