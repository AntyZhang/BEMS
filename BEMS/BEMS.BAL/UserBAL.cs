using BEMS.DAL;
using BEMS.DAL.EF.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.BAL
{
    public class UserBAL
    {
        public static List<Users> GetAllUsers()
        {
            try
            {
                var list = UserDAL.GetAllUsers();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
