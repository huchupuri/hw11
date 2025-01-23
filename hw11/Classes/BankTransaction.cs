 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class BankTransaction
    {
        public DateTime transactionDate { get; private set; }
        public decimal Amount { get; private set; }

        public BankTransaction(decimal Amount)
        {
            this.transactionDate = DateTime.Now;
            this.Amount = Amount;
        }
        public override string ToString()
        {
            return $"дата:{transactionDate}, сумма: {Amount}";
        }
    }
}
