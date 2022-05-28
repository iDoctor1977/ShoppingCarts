using System.Threading.Tasks;

namespace ShoppingCarts.Shared.Core.Interfaces.ICqrs
{
    public interface ICqrsQueryHandler<in TIn, TOut>
    {
        Task<TOut> HandleAsync(TIn model);
    }

    public interface ICqrsQueryHandler<TOut>
    {
        Task<TOut> HandleAsync();
    }
}