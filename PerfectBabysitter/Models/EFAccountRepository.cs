using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public class EFAccountRepository:IAccountRepository
    {
        private ApplicationDbContext context;

        public EFAccountRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Account> Accounts => context.Accounts;

        public void AddAccount(Account account)
        {
            if(account.ID == 0)
            {
                context.Accounts.Add(account);
            }
            else
            {
                var accountEntry = context.Accounts.Single(a => a.ID == account.ID);
                if(accountEntry != null)
                {
                    accountEntry.FirstName = account.FirstName;
                    accountEntry.LastName = account.LastName;
                    accountEntry.Password = account.Password;
                    accountEntry.Birthday = account.Birthday;
                    accountEntry.Gender = account.Gender;
                    accountEntry.Email = account.Email;
                    accountEntry.PhoneNumber = account.PhoneNumber;
                    accountEntry.AccountType = account.AccountType;
                    accountEntry.Resume = account.Resume;
                }
            }
            context.SaveChanges();
        }
    }
}
