using System.Security.Cryptography;
using GroupERPBusiness.Interfaces;
using GroupERPCore.Class;
using GroupERPDatabase.DAL;

namespace GroupERPBusiness.Classes;

public class GroupService : IGroupService
{
    private static int _id = 1;
    public void AddStudentToGroup(int studentid, int groupid)
    {
        Student? student = Database.Students.Find(x => x.Id == studentid);
        Group? group = Database.Groups.Find(x => x.Id == groupid);
        student.Id = _id++;
        if (student == null || group == null)
        {
            throw new NullReferenceException();
        }
        else
        {
            Database.Students.Add(student);
        }
    }

    public void Create(Group group)
    {
        Database.Groups.Add(group);
    }

    public Group Get(int id)
    {
        var wantedgroup = Database.Groups.Find(x => x.Id == id);
        if (wantedgroup is not null)
        {
            return wantedgroup;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public List<Group> GetAll()
    {
        return Database.Groups;
    }

    public void Remove(int id)
    {
        Group? wantedgroup = Database.Groups.Find(x => x.Id == id);
        if (wantedgroup is not null)
        {
            Database.Groups.Remove(wantedgroup);
        }
        else
        {
            throw new NullReferenceException();
        }
    }

}
