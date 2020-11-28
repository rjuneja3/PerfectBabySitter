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

                        JobTitle = "Look after Twins",
                        PhoneNumber = "647-807-0111",
                        Address = "25 College Street, Toronto",
                        Email = "adammichelle@gmail.com",
                        Children = 2,
                        Language = "ENGLISH",
                        Date = "21/11/2020",
                        DatePosted = "12/11/2020",
                        EndTime = "11:59",
                        StartTime = "11:00",
                        Cooking = true,
                        Cleaning = false,
                        Activities = "Listening to music, Playing games",
                        Description = "This is the first job posting sample"

                    },
                    new JobPosting
                    {

                        JobTitle = "Watch over kids play date",
                        PhoneNumber = "647-999-2321",
                        Address = "300 Victoria Street, Toronto",
                        Email = "randomstranger@gmail.com",
                        Children = 5,
                        Language = "FRENCH",
                        Date = "20/11/2020",
                        DatePosted = "8/10/2020",
                        EndTime = "09:59",
                        StartTime = "10:00",
                        Cooking = true,
                        Cleaning = true,
                        Activities = "Driving, Playing games",
                        Description = "This is the second job posting sample"

                    }
             );

            }

            if (!context.AppliedJobs.Any())
            {
                context.AppliedJobs.AddRange(
                    new AppliedJob
                    {
                        ApplicantName = "John Cash",
                        JobId = 1,
                        Status = "Accepted",
                        AppliedStatus="Applied"

                    },
                    new AppliedJob
                    {
                        ApplicantName = "Jake",
                        JobId = 2,
                        Status = "Declined",
                        AppliedStatus="Applied"
                    }
                    );
            }

            context.SaveChanges();

        }
    }
}
