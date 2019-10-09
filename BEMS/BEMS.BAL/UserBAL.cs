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
            //123456
            return "e10adc3949ba59abbe56e057f20f883e";
        }


        public static UserModel CheckLogin(string userName, string Pwd)
        {
            try
            {
                return UserDAL.CheckLogin(userName, Pwd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
