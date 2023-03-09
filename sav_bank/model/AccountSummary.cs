using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.model
{
    public class AccountSummary
    {
        public string Date { get; set; }
        public bool IsDeposit { get; set; }
        public string Amount { get; set; }
        public string CurrentBalance { get; set; }
    }
}
