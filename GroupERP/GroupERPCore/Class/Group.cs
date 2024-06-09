namespace GroupERPCore.Class;

public class Group : BaseModel
{
    private static int _idcounter = 1;
    public string Name { get; set; }
    public string Code { get; set; }

    public Group(string name)
    {
        Id = _idcounter++;
        Name = name;
        Code = CodeChecker(name);

    }
    private string CodeChecker(string name)
    {
        return $"{name.Substring(0, 2).ToUpper()}{Id}";
    }
    public override string ToString()
    {
        return $"id - {Id} name - {Name} code - {Code}";
    }

}
