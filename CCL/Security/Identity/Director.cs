namespace CCL.Security.Identity
{
    public class Director : User
    {
        public Director(int userId, string name, int osnId)
            : base(userId, name, osnId, nameof(Director))
        {
        }
    }
}