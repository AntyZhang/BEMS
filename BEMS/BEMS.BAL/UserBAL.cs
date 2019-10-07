using BEMS.DAL;
using BEMS.DAL.EF.DBModels;
using BEMS.Model;
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

        public static void SaveUserProfile(UserModel userData)
        {
            try
            {
                if (userData.ID.HasValue)
                {
                    UserDAL.UpdateUser(userData);
                }
                else
                {
                    userData.Password = GenerateDefaultPassword();
                    UserDAL.CreateUser(userData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GenerateDefaultPassword()
        {
            return "123456";
        }
    }
}
