using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IHrAccountService
    {
        public Hraccount GetManagementMember(String email);
        public List<Hraccount> GetMemberList();

        public void AddAccount(Hraccount account);

        public void Delete(string email);


        public void Update(Hraccount account);

    }
}
