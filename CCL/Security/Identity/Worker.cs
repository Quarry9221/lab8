namespace CCL.Security.Identity
{
    public class Worker : User
    {
        public Worker(int userId, string name, int osnId)
            : base(userId, name, osnId, nameof(Worker))
        {
        }
    }
}