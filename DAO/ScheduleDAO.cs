using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ScheduleDAO
    {
        private static ScheduleDAO instance = null;

        private ScheduleDAO() { }

        public static ScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScheduleDAO();
                }
                return instance;
            }

        }



        public List<InterviewSchedule> GetSchedules()
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.InterviewSchedules.ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public InterviewSchedule GetById(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();

                return dbContext.InterviewSchedules.SingleOrDefault(p => p.InterviewId.Equals(id));



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddInterview(InterviewSchedule interview)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                InterviewSchedule checkExit = GetById(interview.InterviewId);

                if (checkExit == null)
                {
                    dbContext.InterviewSchedules.Add(interview);
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





        public void DeleteInterview(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                InterviewSchedule interview = GetById(id); // Lấy đối tượng CandidateProfile dựa trên ID
                if (interview != null)
                {
                    dbContext.InterviewSchedules.Remove(interview); // Xóa đối tượng từ DbContext
                    dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UpdateInterview(InterviewSchedule interview)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                if (interview != null)
                {
                    dbContext.InterviewSchedules.Update(interview);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<InterviewSchedule> SearchSchedule(string value)
        {
            try
            {
                using (var dbContext = new CandidateManagement_03Context())
                {
                    return dbContext.InterviewSchedules.Where(p => p.InterviewId.Contains(value)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    

