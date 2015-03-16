using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//using MySql.Data.MySqlClient;
//using MySql.Data;
using System.IO;
using System.Threading;
using SpaDatabase.Model;
using SpaDatabase.Model.Entities;
using SpaDatabase.Repositories;

namespace SpaDatabase.Services
{
    public class DBAccess
    {
        public static bool SubmitToDatabase(SpaDbContext db)
        {
            bool res = false;
           // try
            {
                db.SaveChanges();
                res = true;
            }
            //catch (OptimisticConcurrencyException)
            //{
            //    db.Refresh(System.Data.Objects.RefreshMode.ClientWins, db);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    string info = ex.Message;
            //    if (ex.InnerException != null)
            //    {
            //        info += "\r\n" + ex.InnerException;
            //    }
            //    MessageBox.Show(info);
            //}
            return res;
        }

        #region user
        private static Dictionary<JobPosition, List<UserRole>> _PositionRole = new Dictionary<JobPosition, List<UserRole>>() 
        {
             {JobPosition.Accountant, new List<UserRole>() 
                                        {
                                        }},
             {JobPosition.Cashier, new List<UserRole>() 
                                        {
                                        }},
             {JobPosition.Director, new List<UserRole>() 
                                        {
                                        }},
             {JobPosition.KTV, new List<UserRole>() 
                                        {
                                        }},
             {JobPosition.ViceDirector, new List<UserRole>() 
                                        {
                                        }},
                                       
        };

        public static bool GetPassword(string userName, out string pass, out int privilege)
        {
            bool res = false;
            pass = "";
            privilege = -1;
            using (mochuongspaEntities db = new mochuongspaEntities())
            {
                user query = (from q in db.users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query != null)
                {
                    pass = query.Password;
                    privilege = (int)query.Privilege;
                    res = true;
                }
            }
            return res;
        }
        public static User AddNewUser(string userName, string pass, JobPosition position)
        {
            IRepository<User> repo = new Repository<User>(new SpaDbContext());
            User res = new User();
            res.Name = userName;
            res.Password = pass;
            repo.Insert(res);

            if(_PositionRole.ContainsKey(position))
            {
                foreach(UserRole role in _PositionRole[position])
                {
                    Role r = new Role();
                    r.UserRole = role;
                   
                }
            }
            
            repo.SaveChanges();
            return res;
        }
        public static bool ChangePassword(string userName, string oldPass, string newPass)
        {
            bool res = false;
            using (mochuongspaEntities db = new mochuongspaEntities())
            {
                user query = (from q in db.users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query != null)
                {
                    if (query.Password == oldPass)
                    {
                        query.Password = newPass;
                        res = SubmitToDatabase(db);
                    }
                }
            }
            return res;
        }
        public static bool DeleteUser(string userName)
        {
            bool res = false;
            using (mochuongspaEntities db = new mochuongspaEntities())
            {
                user query = (from q in db.users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query != null)
                {
                    db.users.DeleteObject(query);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }
        public static List<string> GetUserNameList()
        {
            List<string> res = new List<string>();
            using (mochuongspaEntities db = new mochuongspaEntities())
            {
                foreach (user usr in db.users)
                {
                    if (usr.Privilege != 0)
                    {
                        res.Add(usr.Name);
                    }
                }
            }
            return res;
        }
        public static bool UpdateUserPassAndRight(string userName, string pass, int privilege)
        {
            bool res = false;
            using (mochuongspaEntities db = new mochuongspaEntities())
            {
                var query = (from q in db.users
                             where q.Name == userName
                             select q).FirstOrDefault();
                if (query != null)
                {
                    query.Password = pass;
                    query.Privilege = privilege;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }
        #endregion

    }
}
