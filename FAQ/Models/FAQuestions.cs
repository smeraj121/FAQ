using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class FAQuestions
    {

        [Key]
        public int QuestionID { get; set; }

        [Required]
        [Display(Name = "FAQ Title")]
        [StringLength(250, ErrorMessage = "Word limit is 250 characters.")]
        public string QuestionName { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Word limit is 1000 characters.")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }

        public int CategoryID { get; set; }

        [Display(Name = "Site Code")]
        public int SiteCode { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [StringLength(100, ErrorMessage = "Word limit is 100 characters.")]
        public string Tags { get; set; }

        public bool Hide { get; set; }

    }
}