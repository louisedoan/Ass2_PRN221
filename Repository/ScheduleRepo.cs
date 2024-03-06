using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScheduleRepo :IScheduleRepo
    {
        public void AddInterview(InterviewSchedule interview) => ScheduleDAO.Instance.AddInterview(interview);


        public void DeleteInterview(string id) => ScheduleDAO.Instance.DeleteInterview(id);


        public InterviewSchedule GetById(string id) => ScheduleDAO.Instance.GetById(id);


        public List<InterviewSchedule> GetSchedules() => ScheduleDAO.Instance.GetSchedules();

        public List<InterviewSchedule> SearchSchedule(string value) => ScheduleDAO.Instance.SearchSchedule(value);


        public void UpdateInterview(InterviewSchedule interview) => ScheduleDAO.Instance.UpdateInterview(interview);

    }
}
