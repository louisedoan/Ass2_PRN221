using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JobPostService : IJobPostServicecs
    {
        private IJobPostRepo jobPostRepo = null;

        public JobPostService()
        {
            jobPostRepo = new JobPostRepo();
        }

        public void AddJob(JobPosting jobPosting)
        {
            jobPostRepo.AddJob(jobPosting);
        }

        public void DeleteJob(string id)
        {
            jobPostRepo.DeleteJob(id);
        }

        public JobPosting GetById(string id)
        {
            return jobPostRepo.GetById(id);
        }

        public List<JobPosting> GetJobs()
        {
            return jobPostRepo.GetJobs();
        }

        public List<JobPosting> SearchJob(string value)
        {
            return jobPostRepo.SearchJob(value);
        }

        public void UpdateJob(JobPosting job)
        {
            jobPostRepo.UpdateJob(job);
        }
    }
}
