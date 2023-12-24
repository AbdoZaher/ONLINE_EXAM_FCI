using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_EXAM_FCI.Models
{
    public partial class Exam
    {
        [Key]
        public int ExId { get; set; }

       

        public string ExSubject { get; set; } = null!;

        public TimeSpan EXDuration { get; set; }

        [NotMapped]
        public string ExamName { get; set; }

        [NotMapped]
        public int NumQuestions { get; set; }

        [NotMapped]
        public List<ExamQuestion> Questions { get; set; }




    }

    public class ExamQuestion
    {
        public string Question { get; set; }

        public List<string> Choices { get; set; }

        public int CorrectChoice { get; set; }
    }
}