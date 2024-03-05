using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IHrAccountRepo
    {
        public Hraccount GetManagementMember(String email);
        public List<Hraccount> GetMemberList();

        public void AddAccount(Hraccount account);

        public void Delete(string email);

        public void Update(Hraccount account);

    }
}
