﻿using StockPro.CoreBusiness;

namespace StockPro.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy);
        Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy);
    }
}