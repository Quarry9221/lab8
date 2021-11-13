namespace CCL.Security.Identity
{
    public class Admin : User
    {
        public Admin(int userId, string name, int osnId)
            : base(userId, name, osnId, nameof(Admin))
        {
        }
    }
}