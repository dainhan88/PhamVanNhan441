using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using PhamVanNhan441.Models;

namespace PhamVanNhan441.Models
{
    public class CompanyPVN441 : StringProcessPVN441
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã")]
        [Required]
        public string CompanyId { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên")]
        [Required]
        public string CompanyName { get; set; }
    }
}