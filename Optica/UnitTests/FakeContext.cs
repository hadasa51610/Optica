using Optica;
using Optica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class FakeContext : IDataContext
    {
        public List<User> LoadUsers()
        {
            User user=new User();
            user.Name = "hadasa";
            user.BirthDay = DateTime.Now;
            user.EStatus=Status.CUSTOMER;
            user.City = "Bney Brak";
            user.Address = "Kibuth Galuyot 5";
            user.ESickFund = SickFund.MACABI;
            user.Mail = "fgh@gh.com";
            user.Age = 20;
            user.Code = 1;
            user.Phone = "0502145221";
            user.UserId = "123";
            return new List<User> { user};
        }

        public bool SaveUsers(List<User> users)
        {
            return true;
        }
    }
}
