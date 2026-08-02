using System;
using System.Collections.Generic;
using System.Text;

namespace WorldRank.Domain
{
    public class CurrencyRate
    {
        public CurrencyRate(string currencyCode, decimal rate, DateTime date)
        {
            CurrencyCode = currencyCode;
            Rate = rate;
            Date = date;
        }

        public string CurrencyCode { get; }
        public decimal Rate { get; }
        public DateTime Date { get; }
       
    }
}
