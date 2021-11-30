namespace DAL.Entities
{
    public class Street
    {
        public int StreetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int OSNID { get; set; }

        public Street Clone()
        {
            var street = new Street
            {
                Name = Name.Clone() as string,
                Description = Description.Clone() as string,
                StreetID = StreetID,
                OSNID = OSNID
            };
            return street;
        }
    }
}