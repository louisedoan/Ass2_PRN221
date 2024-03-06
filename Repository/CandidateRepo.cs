using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CandidateRepo :ICandidateRepo
    {
        public void AddCadidate(CandidateProfile candidate) => CandidateDAO.Instance.AddCadidate(candidate);

        public void DeleteCandidate(string id) => CandidateDAO.Instance.DeleteCandidate(id);




        public List<CandidateProfile> GetAllCandidate() => CandidateDAO.Instance.GetAllCandidate();

        public CandidateProfile GetById(string id) => CandidateDAO.Instance.GetById(id);

        public List<CandidateProfile> SearchCandidatss(string value) => CandidateDAO.Instance.SearchCandidatss(value);


        public void UpdateCandidate(CandidateProfile profile) => CandidateDAO.Instance.UpdateCandidate(profile);

    }
}
