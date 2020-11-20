using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.JobPostings.Any())
            {
                context.JobPostings.AddRange(
                    new JobPosting
                    {
                       
                        PhoneNumber = "38728233",
                        Email = "Rohansjads@gmail.com",
                        Address = "7843 Toronto",
                        Children = "2",
                        Language = "ENGLISH",
                        Description = "blahblah",
                        Date = "11/11/2019",
                        EndTime = "11:59",
                        StartTime =  "11:00"

                    },
                    new JobPosting
                    {
                        
                        PhoneNumber = "3243",
                        Email = "test@gmail.com",
                        Address = "111 Toronto",
                        Children = "2",
                        Language = "HINDI",
                        Description = "blah blah",
                        Date = "11/11/2019",
                        EndTime = "11:59",
                        StartTime = "11:00"

                    }
             ) ;
            
            context.SaveChanges();
        }
    }
}
}
