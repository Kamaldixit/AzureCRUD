using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.dao;
using Azure.model;

using System.Data.Entity;

using Azure.dbconfig;


namespace Azure.daoimpl
{
    class UserDetailsImpl : UserDetailsDAO 
    {
        public List<UserDetails> userList = new List<UserDetails>();


        public UserDetailsImpl()
            
        {


        }

        bool UserDetailsDAO.addUser(UserDetails user) 
        {
            int x = 0;
            while (x == 0)
            {
                int i = 0;
                Console.Write("Enter ID : ");
                user.UserId1 = Int32.Parse(Console.ReadLine());

                using (var context = new MyDbContext())
                {
                    var check =
                            from n in context.UserDetails
                            where n.UserId1 == user.UserId1
                            select n;

                    if (check == null || check.Count() == 0)
                        i = 0;

                    else {
                       
                        i = 1;
                    }
                }

                if (i==0)
                {

                    x = 1;

                    try
                    {
                        //userList.Add(user);
                        //var dbInitializer = new DropCreateDatabaseIfModelChanges<MyDbContext>();
                        //dbInitializer.InitializeDatabase(new MyDbContext());

                        using (var context = new MyDbContext())
                        {
                            context.UserDetails.Add(user);
                            context.SaveChanges();
                        }
                        Console.WriteLine("\n\nData added successfully.\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return false;
                    }
                    
                }
                else if (i==1)
                {
                    Console.WriteLine("\n\nID already exist....\nPlease choose another ID.");
                    
                }
            }
                
                return true;      
        }

        bool UserDetailsDAO.removeUser(UserDetails user)
        {
            UserDetails um = new UserDetails();
            /*int o = 0;
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList.ElementAt(i).UserId1 == user.UserId1)
                    o = i;
            }*/

            using (var context = new MyDbContext())
            {
                um = (from n in context.UserDetails where n.UserId1 == user.UserId1 select n).Single();
                context.UserDetails.Remove(um);
                context.SaveChanges();
            }


            return true;
                    
        }

        bool UserDetailsDAO.updateUser(UserDetails user)
        {
            using (var context = new MyDbContext())
            {
                var update =
                        from n in context.UserDetails
                        where n.UserId1 == user.UserId1
                        select n;

                foreach (UserDetails u in update)
                {
                    u.Name = user.Name;
                    u.Age = user.Age;
                    u.UserAdress = user.UserAdress;
                    u.UserPassword = user.UserPassword;
                    u.UserMobile = user.UserMobile;
                    u.UserEmail = user.UserEmail;
                    u.UserStatus = user.UserStatus;
                    u.UserRole= user.UserRole;
                    
                }

                // Submit the changes to the database.
                try
                {
                    context.SaveChanges();
                    Console.WriteLine("\nChanges Saved......\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }

                /* = (from n in context.UserDetails where n.UserId1 == user.UserId1 select n).Single();
                context.UserDetails.(um);
                context.SaveChanges();*/
            }
            

            return true;


           /* userList.ElementAt(user.Id).Age = userList.Age;
            userList.ElementAt(i).Name1us = Name;
            * */

        }
        
        List<UserDetails> UserDetailsDAO.getAllUsers()
            {
                List<UserDetails> mList = new List<UserDetails>();
                using (var context = new MyDbContext())
                {
                    mList = (from n in context.UserDetails select n).ToList();

                }
            if(mList.Count < 1)
            {
                Console.WriteLine("\nTable is empty...\n");
            }

                return mList;
            }

        /*bool UserDetailsDAO.displayData(UserDetails user)
        {
            Console.Write(userList.ElementAt(i).Id + "\t");
            Console.Write(userList.ElementAt(i).Name1 + "\t");
            Console.Write(userList.ElementAt(i).Age + "\t");

            return true;
        }
        */

        UserDetails UserDetailsDAO.getUsersById(UserDetails user) 
        {
            int o = 0, f = 0;
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList.ElementAt(i).UserId1 == user.UserId1)
                { o = i; }
                else
                    f = 1;
            }
            if (f == 1)  
            {
                Console.WriteLine("record not found");
            }
            /*
            Console.Write(userList.ElementAt(index).Id + "\t");
            Console.Write(userList.ElementAt(index).Name1 + "\t");
            Console.Write(userList.ElementAt(i).Age + "\t");
            */
            using (var context = new MyDbContext())
            {
                UserDetails mUser = (from u in context.UserDetails where u.UserId1 == user.UserId1 select u).Single();
                context.SaveChanges();
                Console.WriteLine(mUser.Name + "\t" + mUser.UserId1 + "\t" + mUser.Age);


            }
            
            

            return userList.ElementAt(o);
        }


        UserDetails UserDetailsDAO.getSqlDataById(UserDetails user)
                {
                    UserDetails u = new UserDetails();

                    //var dbInitializer = new CreateDatabaseIfNotExists<MyDbContext>();
                    //dbInitializer.InitializeDatabase(new MyDbContext());

                    using (var context = new MyDbContext())
                    {
                        u = context.UserDetails.Find(user.Id);

                        
                    }


                    return u;

                }

        UserDetails UserDetailsDAO.getSqlDataByUserId(UserDetails user)
        {
            UserDetails u = new UserDetails();

            //var dbInitializer = new CreateDatabaseIfNotExists<MyDbContext>();
           // dbInitializer.InitializeDatabase(new MyDbContext());

            try { 
            using (var context = new MyDbContext())
            {
                u = (from n in context.UserDetails where n.UserId1 == user.UserId1 select n).Single();

            }

            }
            catch (Exception e)
            {
                Console.WriteLine("\nRecord not found : \n" + e);
            }

            return u;


        }

        
        }
}
