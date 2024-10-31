
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    
    public class AddBookViewModel
    {
        public string? id { get; set; } 
        
        [Required]
        public string Isbn { get; set; }
        
        public string Notes { get; set; }
      
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Title { get; set; }
        public int SubjectId { get; set; }
     
        public int PublisherId { get; set; }
      
    }
}
