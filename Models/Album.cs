namespace PlaySoftBeta.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int albumID { get; set; }
        public string albumDescriptionName { get; set; }
        public string? albumDescription { get; set; }
        
        public int artistID { get; set; }
        public Artist Artist { get; set; }
        
    }
}