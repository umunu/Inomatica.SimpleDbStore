using System.Data;
using Inomatica.UnitRepo;

namespace ExampleStore
{
    public class FooDbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            throw new System.NotImplementedException();
        }
    }

    public class OrderLineRepository : RepositoryBase<FooDbConnectionFactory>
    {
        public OrderLineRepository(IUnitOfWork<FooDbConnectionFactory> unitOfWork)
            : base(unitOfWork) { }

    }

    public class OrderItemRepository : RepositoryBase<FooDbConnectionFactory>
    {
        public OrderItemRepository(IUnitOfWork<FooDbConnectionFactory> unitOfWork)
            : base(unitOfWork) { }

    }


    public class SaleService
    {
        private readonly OrderItemRepository _orderItemRepository;
        private readonly OrderLineRepository _orderLineRepository;

        public SaleService(
            OrderItemRepository orderItemRepository,
            OrderLineRepository orderLineRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderLineRepository = orderLineRepository;
        }

        public void SubmitSale()
        {
            _orderItemRepository.UnitOfWork.UseTransaction();

            _orderItemRepository.UnitOfWork.Commit();

        }
    }
}
