using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
