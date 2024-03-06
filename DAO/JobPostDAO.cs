using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class JobPostDAO
    {
        private static JobPostDAO instance = null;

        private JobPostDAO() { }

        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();
                }
                return instance;
            }

        }

        public List<JobPosting> GetJobs()
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.JobPostings.ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public JobPosting GetById(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.JobPostings.SingleOrDefault(p => p.PostingId.Equals(id));



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddJob(JobPosting jobPosting)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                JobPosting checkExit = GetById(jobPosting.PostingId);

                if (checkExit == null)
                {
                    dbContext.JobPostings.Add(jobPosting);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Job ID is existed");
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public void DeleteJob(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                JobPosting jobPosting = GetById(id); // Lấy đối tượng CandidateProfile dựa trên ID
                if (jobPosting != null)
                {
                    dbContext.JobPostings.Remove(jobPosting); // Xóa đối tượng từ DbContext
                    dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UpdateJob(JobPosting job)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                if (job != null)
                {
                    dbContext.JobPostings.Update(job);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<JobPosting> SearchJob(string value)
        {
            try
            {
                using (var dbContext = new CandidateManagement_03Context())
                {
                    return dbContext.JobPostings.Where(p => p.JobPostingTitle.Contains(value)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
