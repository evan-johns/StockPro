﻿using StockPro.CoreBusiness;

namespace StockPro.UseCases.Activities.Interfaces
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
    }
}