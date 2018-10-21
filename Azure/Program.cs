using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.model;
using System.Data.Entity;
using Azure.dbconfig;
using Azure.daoimpl;
using Azure.dao;

namespace Azure
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbInitializer = new DropCreateDatabaseIfModelChanges<MyDbContext>();
            dbInitializer.InitializeDatabase(new MyDbContext());

            UserDetailsImpl imp = new UserDetailsImpl();
            UserDetailsDAO dao = new UserDetailsImpl();


            int i;
            string ch = "y";








            while (!ch.Equals("n"))
            {

                Console.WriteLine("======================\n1. Add User \n2. Delete User  \n3. Update User \n4. Get All User \n5. Get Data by ID \n======================");
                Console.Write("\nEnter your Choice :  ");
                i = Int32.Parse(Console.ReadLine());

                if (i < 6)
                {


                    switch (i)
                    {

                        case 1:
                            UserDetails u = new UserDetails();
                            Console.Write("\nEnter Name : ");
                            u.Name = Console.ReadLine();
                            Console.Write("Enter Age : ");
                            u.Age = Int32.Parse(Console.ReadLine());

                            Console.Write("\nEnter Email : ");
                            u.UserEmail = Console.ReadLine();

                            Console.Write("\nEnter Password : ");
                            u.UserPassword = Console.ReadLine();

                            Console.Write("\nEnter Mobile : ");
                            u.UserMobile = long.Parse(Console.ReadLine());

                            Console.Write("\nEnter Adress : ");
                            u.UserAdress = Console.ReadLine();

                            Console.Write("\nEnter Role : ");
                            u.UserRole = Console.ReadLine();

                            Console.Write("\nEnter Status : ");
                            u.UserStatus = Console.ReadLine();


                            dao.addUser(u);

                            break;

                        case 2:
                            string delChoice = "y";
                            while (!delChoice.Equals("n"))
                            {

                                Console.Write("\nEnter ID to Delete: ");
                                UserDetails ud = new UserDetails();
                                ud.UserId1 = Int32.Parse(Console.ReadLine());
                                ud = dao.getSqlDataByUserId(ud);
                                Console.WriteLine(ud.UserId1 + "\t" + ud.Name + "\t" + ud.Age + "\t" + ud.UserAdress + "\t" + ud.UserEmail + "\t" + ud.UserPassword + "\t" + ud.UserMobile + "\t" + ud.UserRole + "\t" + ud.UserStatus);
                                Console.Write("Do you wanna delete this record? (y/n) : ");
                                string mchoice = Console.ReadLine();

                                if (mchoice == "y" || mchoice == "Y")
                                {
                                    dao.removeUser(ud);
                                    Console.WriteLine("Data deleted successfully.");
                                    Console.Write("Delete more? (y/n) : ");

                                    delChoice = Console.ReadLine();

                                }

                                else if (mchoice == "n" || mchoice == "N")
                                {
                                    continue;
                                }

                                else
                                {
                                    Console.WriteLine("Invalid input");
                                }

                            }



                            break;

                        case 3:
                            UserDetails uu = new UserDetails();
                            Console.Write("Enter the User ID to update data : ");
                            uu.UserId1 = Int32.Parse(Console.ReadLine());

                            Console.Write("New Name : ");
                            uu.Name = Console.ReadLine();

                            //Console.Write("New ID : ");
                            // uu.UserId1 = Int32.Parse(Console.ReadLine());

                            Console.Write("New Age : ");
                            uu.Age = Int32.Parse(Console.ReadLine());

                            Console.Write("New Adress : ");
                            uu.UserAdress = Console.ReadLine();

                            Console.Write("New Email : ");
                            uu.UserEmail = Console.ReadLine();

                            Console.Write("New Password : ");
                            uu.UserPassword = Console.ReadLine();

                            Console.Write("\nNew Mobile : ");
                            uu.UserMobile = long.Parse  (Console.ReadLine());

                            Console.Write("New Role : ");
                            uu.UserRole = Console.ReadLine();

                            Console.Write("New Status : ");
                            uu.UserStatus = Console.ReadLine();

                            dao.updateUser(uu);

                            break;
                        case 4:
                            List<UserDetails> uall = dao.getAllUsers();
                            Console.WriteLine("\n\nID\tName\tAge\n===================");

                            foreach (UserDetails ur in uall)
                            {

                                Console.WriteLine(ur.UserId1 + "\t" + ur.Name + "\t" + ur.Age + "\t" + ur.UserAdress + "\t" + ur.UserEmail + "\t" + ur.UserPassword + "\t" + ur.UserMobile + "\t" + ur.UserRole + "\t" + ur.UserStatus);
                                Console.WriteLine("-------------------");

                            }
                            break;

                        case 5:
                            UserDetails x = new UserDetails();
                            UserDetails y = new UserDetails();

                            Console.WriteLine("1. Get data by ID \n2. Get data by User ID");
                            int choice = Int32.Parse(Console.ReadLine());

                            if (choice == 1)
                            {
                                Console.Write("Enter ID: ");
                                x.Id = Int32.Parse(Console.ReadLine());
                                y = dao.getSqlDataById(x);
                                Console.WriteLine(y.UserId1 + "\t" + y.Name + "\t" + y.Age + "\t" + y.UserAdress + "\t" + y.UserEmail + "\t" + y.UserPassword + "\t" + y.UserMobile + "\t" + y.UserRole + "\t" + y.UserStatus);
                            }

                            else if (choice == 2)
                            {
                                Console.WriteLine("Enter User ID : ");
                                x.UserId1 = Int32.Parse(Console.ReadLine());
                                y = dao.getSqlDataByUserId(x);
                                Console.WriteLine(y.UserId1 + "\t" + y.Name + "\t" + y.Age + "\t" + y.UserAdress + "\t" + y.UserEmail + "\t" + y.UserPassword + "\t" + y.UserMobile + "\t" + y.UserRole + "\t" + y.UserStatus);
                            }

                            else
                            {
                                Console.WriteLine("Invalid Option.....\nPlease try again.");
                                continue;
                            }


                            break;


                    }

                }

                else
                {
                    Console.WriteLine("\nInvalid Option.....\nPlease try again.\n");
                    continue;
                }


                Console.Write("\n\nRun prrogramme again? (y/n) : ");
                ch = Console.ReadLine();

                Console.WriteLine("\n\n");
            }

        }
    }
}
