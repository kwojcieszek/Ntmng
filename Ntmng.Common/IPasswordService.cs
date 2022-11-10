namespace Ntmng.Common;

public interface IPasswordService
{
    public string HashPassword(string password);
    public bool ComparePassword(string password, string hashPassword);
}