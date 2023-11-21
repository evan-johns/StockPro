using StockPro.CoreBusiness;

namespace StockPro.UseCases.Products.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}