namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userID, string name, int osnID, string userType)
        {
            UserId = userID;
            Name = name;
            OSNID = osnID;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int OSNID { get; }
        public string UserType { get; }

    }
}