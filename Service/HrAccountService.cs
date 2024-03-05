using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HrAccountService : IHrAccountService
    {
        private IHrAccountRepo memRepo;

        public HrAccountService()
        {
            memRepo = new HrAccountRepo();
        }

        public void AddAccount(Hraccount account)
        {
            memRepo.AddAccount(account);
        }

        public void Delete(string email)
        {
            memRepo.Delete(email);   
        }

        public Hraccount GetManagementMember(string email)
        {
            return memRepo.GetManagementMember(email);
        }

        public List<Hraccount> GetMemberList()
        {
            return memRepo.GetMemberList();
        }

        public void Update(Hraccount account)
        {
          memRepo.Update(account);
        }
    }
}
