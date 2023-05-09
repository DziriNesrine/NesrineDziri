namespace NesrineDziri.Models
{
    public  class Perfumery_Store
    {

        public Perfumery_Store()
        {
            MakeUps = new HashSet<MakeUp>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<MakeUp> MakeUps { get; set; } = new List<MakeUp>();

      
    }
}
