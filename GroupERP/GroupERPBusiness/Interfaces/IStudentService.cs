using GroupERPCore.Class;

namespace GroupERPBusiness.Interfaces;

public interface IStudentService
{
    public void Create(Student student);
    public void Remove(int id);
    public Student Get(int id);
    public List<Student> GetAll();

}
