using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HrAccountRepo : IHrAccountRepo
    {
        public Hraccount GetManagementMember(string email)=> HrAccountDAO.Instance.GetManagementMember(email);

        public List<Hraccount> GetMemberList()=>HrAccountDAO.Instance.GetMemberList();
        
    }
}
