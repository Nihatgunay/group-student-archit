using System.Globalization;

namespace GroupERPCore.Class;

public class Student : BaseModel
{
    private static int _idcounter = 1;
    public string FullName { get; set; }
    public double Grade { get; set; }
    public Student(string fullname, double grade)
    {
        Id = _idcounter++;
        FullName = fullname;
        Grade = grade;
    }
    public override string ToString()
    {
        return $"id - {Id} fullname - {FullName} grade - {Grade}";
    }

}
