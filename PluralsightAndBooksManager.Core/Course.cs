using System.ComponentModel.DataAnnotations;

namespace PluralsightAndBooksManager.Core
{
    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Is in collection?")]
        public bool IsInCollection { get; set; }
    }   
}
