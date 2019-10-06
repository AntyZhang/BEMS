using BEMS.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using BEMS.DAL.EF.DBModels;

namespace BEMS.DAL
{
    public class UserDAL
    {
        public static List<Users> GetAllUsers()
        {
            using (var context = new BEMSContext())
            {
                var list = context.Users.ToList();
                return list;
            }

        }
    }
}
