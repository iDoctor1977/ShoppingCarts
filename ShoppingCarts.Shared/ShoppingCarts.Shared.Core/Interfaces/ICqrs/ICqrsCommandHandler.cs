using System.Threading.Tasks;

namespace ShoppingCarts.Shared.Core.Interfaces.ICqrs
{
    public interface ICqrsCommandHandler<in T>
    {
        public Task HandleAsync(T model);
    }
}