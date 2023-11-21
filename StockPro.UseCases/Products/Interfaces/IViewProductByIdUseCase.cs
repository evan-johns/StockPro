using StockPro.CoreBusiness;

namespace StockPro.UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product?> ExecuteAsync(int productId);
    }
}