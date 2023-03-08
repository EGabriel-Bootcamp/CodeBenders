using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.model
{
    public class BankResponse<T>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
