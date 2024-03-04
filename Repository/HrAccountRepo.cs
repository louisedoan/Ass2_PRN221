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
        public void AddAccount(Hraccount account)=> HrAccountDAO.Instance.AddAccount(account);

        public void Delete(string email)=>HrAccountDAO.Instance.Delete(email);
       

        public Hraccount GetManagementMember(string email)=> HrAccountDAO.Instance.GetManagementMember(email);

        public List<Hraccount> GetMemberList()=>HrAccountDAO.Instance.GetMemberList();
        
    }
}
