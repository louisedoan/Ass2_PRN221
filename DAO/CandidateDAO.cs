using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CandidateDAO
    {

        private static CandidateDAO instance = null;

        private CandidateDAO() { }

        public static CandidateDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateDAO();
                }
                return instance;
            }

        }



        public List<CandidateProfile> GetAllCandidate()
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.CandidateProfiles.ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public CandidateProfile GetById(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.CandidateProfiles.SingleOrDefault(p => p.CandidateId.Equals(id));



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddCadidate(CandidateProfile candidate)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                CandidateProfile checkExit = GetById(candidate.CandidateId);

                if (checkExit == null)
                {
                    dbContext.CandidateProfiles.Add(candidate);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Candidate ID is existed");
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public void DeleteCandidate(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                CandidateProfile candidate = GetById(id); // Lấy đối tượng CandidateProfile dựa trên ID
                if (candidate != null)
                {
                    dbContext.CandidateProfiles.Remove(candidate); // Xóa đối tượng từ DbContext
                    dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UpdateCandidate(CandidateProfile profile)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                if (profile != null)
                {
                    dbContext.CandidateProfiles.Update(profile);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<CandidateProfile> SearchCandidatss(string value)
        {
            try
            {
                using (var dbContext = new CandidateManagement_03Context())
                {
                    return dbContext.CandidateProfiles.Where(p => p.Fullname.Contains(value)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
