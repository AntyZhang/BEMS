using BEMS.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using BEMS.DAL.EF.DBModels;
using BEMS.Model;

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

        public static void CreateUser(UserModel userData)
        {
            using (var context = new BEMSContext())
            {
                var user = context.Users.SingleOrDefault(a => a.AccountName.Equals(userData.AccountName));
                if (user != null)
                {
                    throw new ArgumentException("账号已存在");
                }
                context.Users.Add(new Users()
                {
                    AccountName = userData.AccountName,
                    Address = userData.Address,
                    CreateBy = userData.CreateBy,
                    CreateTime = userData.CreateTime,
                    DisplayName = userData.DisplayName,
                    LastModifyBy = userData.LastModifyBy,
                    LastModifyTime = userData.LastModifyTime,
                    Memo = userData.Memo,
                    Password = userData.Password,
                    Phone = userData.Phone,
                    State = userData.State
                });
                context.SaveChanges();
            }
        }

        public static void UpdateUser(UserModel userData)
        {
            using (var context = new BEMSContext())
            {

                var user = context.Users.SingleOrDefault(a => a.ID == userData.ID);
                if (user != null)
                {
                    user.Address = userData.Address;
                    user.DisplayName = userData.DisplayName;
                    user.LastModifyBy = userData.LastModifyBy;
                    user.LastModifyTime = userData.LastModifyTime;
                    user.Memo = userData.Memo;
                    user.Phone = userData.Phone;
                }
                else
                {
                    throw new NullReferenceException("用户不存在！");
                }
                context.SaveChanges();
            }
        }
    }
}
