using System.Diagnostics.CodeAnalysis;
using System.IO.IsolatedStorage;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using GroupERPBusiness.Classes;
using GroupERPBusiness.Interfaces;
using GroupERPCore.Class;
using GroupERPDatabase.DAL;
using Group = GroupERPCore.Class.Group;


namespace GroupERPCA;

internal class Program
{
    static void Main(string[] args)
    {
        //int num = 2;
        //int sum = 0;
        //for (int i = 1; i < 1000; i++)
        //{
        //    num = num * 2;
        //}
        //string numstr = num.ToString();
        //for (int j = 0; j < numstr.Length; j++)
        //{
        //    sum += numstr[j] - '0';
        //}
        //Console.WriteLine(sum);



        IStudentService studentservice = new StudentService();
        IGroupService groupservice = new GroupService();
        while (true)
        {
            Console.WriteLine("1. Group Operations:");
            Console.WriteLine("2. Student Operations:");
            Console.WriteLine("3. Add student to group:");
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("  1. Create() Group\r\n  2. Get() Group\r\n  3. GetAll() Groups\r\n  4. Remove() Group\r\n  5. Exit");
                    Console.Write("Your choice: ");
                    int choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.Write("Enter Group Name: ");
                            string name = Console.ReadLine();
                            Group group = new Group(name);
                            groupservice.Create(group);
                            break;
                        case 2:
                            Console.Write("Enter Group id: ");
                            int groupid = int.Parse(Console.ReadLine());
                            Group getgroup = groupservice.Get(groupid);
                            Console.WriteLine(getgroup); 
                            break;
                        case 3:
                            foreach (var grp in groupservice.GetAll())
                            {
                                Console.WriteLine(grp);
                            }
                            break;
                        case 4:
                            Console.Write("Enter Group id to remove: ");
                            int groupidremove = int.Parse(Console.ReadLine());
                            groupservice.Remove(groupidremove);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("  1. Create() Student\r\n  2. Get() Student\r\n  3. GetAll() Student\r\n  4. Remove() Student\r\n  5. Exit");
                    Console.Write("Your choice: ");
                    int choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            Console.Write("Enter student fullname: ");
                            string fullname = Console.ReadLine();
                            Console.Write("Enter student grade: ");
                            double grade = double.Parse(Console.ReadLine());
                            Student student = new Student(fullname, grade);
                            studentservice.Create(student);
                            break;
                        case 2:
                            Console.Write("Enter student id: ");
                            int studentid = int.Parse(Console.ReadLine());
                            Student getstd = studentservice.Get(studentid);
                            Console.WriteLine(getstd);
                            break;
                        case 3:
                            foreach (var std in studentservice.GetAll())
                            {
                                Console.WriteLine(std);
                            }
                            break;
                        case 4:
                            Console.Write("Enter student id to remove: ");
                            int studentidremove = int.Parse(Console.ReadLine());
                            studentservice.Remove(studentidremove);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("GROUPS: ");
                    foreach (var group in groupservice.GetAll())
                    {
                        Console.WriteLine(group);
                    }
                    Console.Write("Enter group id: ");
                    int groupchoice = int.Parse(Console.ReadLine());
                    Group selectedgroup = groupservice.Get(groupchoice);
                    if (selectedgroup == null)
                    {
                        Console.WriteLine("Group cant be null");
                    }
                    else
                    {
                        Console.WriteLine("STUDENTS: ");
                        foreach (var student in studentservice.GetAll().Where(x => !Database.Groups.Any(y => y.Id == x.Id)))
                        {
                            Console.WriteLine(student);
                        }
                        Console.WriteLine("Enter student id: ");
                        int studentchoice = int.Parse(Console.ReadLine());
                        Student selectedstudent = studentservice.Get(studentchoice);
                        if (selectedstudent != null )
                        {
                            groupservice.AddStudentToGroup(studentchoice, groupchoice);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student id");
                        }


                    }
                    break;
            }
        }
        }

    }

