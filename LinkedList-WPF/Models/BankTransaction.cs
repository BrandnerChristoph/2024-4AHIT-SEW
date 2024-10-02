using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_WPF.Models
{
    public class BankTransaction : IIdentifier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        public BankTransaction(double amount, string name = null)
        {
            this.Id = Guid.NewGuid().ToString().Substring(0,8);
            this.Amount = amount;
            this.Name = name;
            this.CreatedAt = DateTime.Now;
        }
    }
}
