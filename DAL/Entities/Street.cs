namespace DAL.Entities
{
    public class Street
    {
        public int StreetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int OSNID { get; set; }
        public OSN OSN { get; set; }
    }
}