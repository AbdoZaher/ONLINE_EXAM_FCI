using ONLINE_EXAM_FCI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINE_EXAM_FCI.Models;
public partial class User
{
    [Key]
   
    public int Id { get; set; }
    [Required]  
    public string UserName { get; set; }
    

    [Required]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter Valid E-mail")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string PasswordConfirmed { get; set; }
    [Required]
    public string photo { get; set; }

    [Required]
    [DefaultValue(1)]
    public int RoleID { get; set; } = 2;

    //[Required]
    //[Display(Name = "User Type")]
    //public string UserType { get; set; }


}
