namespace ContatoApi.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString(string name);
    }
}