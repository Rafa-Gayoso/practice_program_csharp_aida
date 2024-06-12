using System;

namespace StockBroker
{
    public record OrderSummary
    {
        private readonly decimal _boughtAmount;
        private readonly decimal _soldAmount;
        private readonly DateOnly _orderDate;

        public OrderSummary(DateOnly orderDate, decimal boughtAmount, decimal soldAmount)
        {
            _orderDate = orderDate;
            _boughtAmount = boughtAmount;
            _soldAmount = soldAmount;
        }

        public DateOnly Date()
        {
            return _orderDate;
        }

        public decimal BoughtAmount()
        {
            return _boughtAmount;
        }

        public decimal SoldAmount()
        {
            return _soldAmount;
        }
    }
}
