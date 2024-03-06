using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CandidateService :ICandidateService
    {
        private ICandidateRepo candidateRepo = null;

        public CandidateService()
        {
            candidateRepo = new CandidateRepo();
        }

        public void AddCadidate(CandidateProfile candidate)
        {
            candidateRepo.AddCadidate(candidate);
        }

        public void DeleteCandidate(string id)
        {
            candidateRepo.DeleteCandidate(id);
        }

        public List<CandidateProfile> GetAllCandidate()
        {
            return candidateRepo.GetAllCandidate();
        }

        public CandidateProfile GetById(string id)
        {
            return (candidateRepo.GetById(id));
        }

        public List<CandidateProfile> SearchCandidatss(string value)
        {
            return (candidateRepo.SearchCandidatss(value));
        }

        public void UpdateCandidate(CandidateProfile profile)
        {
            candidateRepo.UpdateCandidate(profile);
        }
    }
}
