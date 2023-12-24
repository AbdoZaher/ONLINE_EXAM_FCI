using ONLINE_EXAM_FCI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_EXAM_FCI.Models;

public partial class Attendance
{
    [Key]
    public int AttdId { get; set; }

    public int? StudId { get; set; }

    public virtual User? Stud { get; set; }
}
