using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public interface IAccountRepository
    {
        IQueryable<Account> Accounts {get;}

        void AddAccount(Account account);
    }
}
