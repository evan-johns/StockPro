using StockPro.CoreBusiness;
using StockPro.UseCases.PluginInterfaces;
using StockPro.UseCases.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPro.UseCases.Reports
{
    public class SearchProductTransactionsUseCase : ISearchProductTransactionsUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;

        public SearchProductTransactionsUseCase(IProductTransactionRepository productTransactionRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
                string productName,
                DateTime? dateFrom,
                DateTime? dateTo,
                ProductTransactionType? transactionType
            )
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

            return await this.productTransactionRepository.GetProductTransactionsAsync(
                    productName,
                    dateFrom,
                    dateTo,
                    transactionType
                );
        }
    }
}
