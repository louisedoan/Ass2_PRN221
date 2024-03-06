using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JobPostRepo : IJobPostRepo
    {
        public void AddJob(JobPosting jobPosting) => JobPostDAO.Instance.AddJob(jobPosting);


        public void DeleteJob(string id) => JobPostDAO.Instance.DeleteJob(id);


        public JobPosting GetById(string id) => JobPostDAO.Instance.GetById(id);


        public List<JobPosting> GetJobs() => JobPostDAO.Instance.GetJobs();

        public List<JobPosting> SearchJob(string value) => JobPostDAO.Instance.SearchJob(value);

        public void UpdateJob(JobPosting job) => JobPostDAO.Instance.UpdateJob(job);

    }
}
