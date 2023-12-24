using ONLINE_EXAM_FCI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_EXAM_FCI.Models;

    public class StudentExam
    {
        //[ForeignKey("Student")]
        [Key]
        public User student { get; set; }

        // [ForeignKey("Exam")]

        public int ExamId { get; set; }

       
        public Exam Exam { get; set; }
    }

