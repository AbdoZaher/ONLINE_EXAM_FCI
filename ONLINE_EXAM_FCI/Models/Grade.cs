using ONLINE_EXAM_FCI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_EXAM_FCI.Models;

public partial class Grade
{
    [Key]
    public int GrdId { get; set; }

    public int GrdMark { get; set; }

    public int? StudId { get; set; }

   
}
