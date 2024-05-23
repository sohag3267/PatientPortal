namespace ApplicationCore.Entities
{
    public class NCD_Detail
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NCDId { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public NCD NCD { get; set; }
    }

}
