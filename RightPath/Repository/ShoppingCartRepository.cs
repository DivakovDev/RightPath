using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;
using System.Linq.Expressions;

namespace RightPath.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ShoppingCart obj)
        {
            _context.ShoppingCarts.Update(obj);
        }
    }
}
