using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IJobPostServicecs
    {
        List<JobPosting> GetJobs();
        public JobPosting GetById(string id);
        public void AddJob(JobPosting jobPosting);
        public void DeleteJob(string id);

        public void UpdateJob(JobPosting job);

        public List<JobPosting> SearchJob(string value);
    }
}
