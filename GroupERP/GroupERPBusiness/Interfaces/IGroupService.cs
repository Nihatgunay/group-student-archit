using GroupERPCore.Class;

namespace GroupERPBusiness.Interfaces;

public interface IGroupService
{
    public void Create(Group group);
    public void Remove(int id);
    public Group Get(int id);
    public List<Group> GetAll();
    public void AddStudentToGroup(int studentid, int groupid);
}
