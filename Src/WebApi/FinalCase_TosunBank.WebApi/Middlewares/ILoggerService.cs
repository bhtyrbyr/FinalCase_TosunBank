namespace WebAPI.Services
{
    public interface ILogService
    {
        public void Write(params object[] messageParams);
    } 
}