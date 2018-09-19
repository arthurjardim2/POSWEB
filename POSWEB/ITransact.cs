namespace POSWEB
{
    public interface ITransact
    {
        string Execute(string psIp, int psPort, string psMessage);
    }
}