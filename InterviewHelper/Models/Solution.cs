using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewHelper.Models
{
    public class Solution
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SolutionId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string SolutionDetails { get; set; }
    }
}