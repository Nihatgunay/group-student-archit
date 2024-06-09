using GroupERPBusiness.Interfaces;
using GroupERPCore.Class;
using GroupERPDatabase.DAL;

namespace GroupERPBusiness.Classes;

public class StudentService : IStudentService
{
    public void Create(Student student)
    {
        Database.Students.Add(student);
    }
    public void Remove(int id)
    {
        var wantedstudent = Database.Students.Find(x => x.Id == id);
        if (wantedstudent is not null)
        {
            Database.Students.Remove(wantedstudent);
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public Student Get(int id)
    {
        Student? wantedstudent = Database.Students.Find(x => x.Id == id);
        if (wantedstudent is not null)
        {
            return wantedstudent;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public List<Student> GetAll()
    {
        return Database.Students;
    }

}
