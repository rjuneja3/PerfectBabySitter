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
            var accountEntry = context.Accounts.Find(account.Id);
            if (accountEntry == null)
            {
                context.Accounts.Add(account);
            }
            else
            {
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
