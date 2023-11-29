using StockPro.CoreBusiness;

namespace StockPro.UseCases.Reports.Interfaces
{
    public interface ISearchProductTransactionsUseCase
    {
        Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
    }
}