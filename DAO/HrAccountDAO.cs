using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   
    
    public class HrAccountDAO
    {
        private static HrAccountDAO instance = null;
        private readonly CandidateManagement_03Context dbContext = null;


        private HrAccountDAO() { 
            dbContext = new CandidateManagement_03Context();
        }

        public static HrAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HrAccountDAO();
                }
                return instance;
            }

        }



        public Hraccount GetManagementMember(String email)
        {
            var dbContext = new CandidateManagement_03Context();
            //   return dbContent.BookManagementMembers.SingleOrDefault(p => p.Email.Equals(email));

            return dbContext.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));

        }

        public List <Hraccount> GetMemberList()
        {
            var dbContext = new CandidateManagement_03Context();
            //   return dbContent.BookManagementMembers.SingleOrDefault(p => p.Email.Equals(email));

            return dbContext.Hraccounts.ToList();
        }

    }
}
