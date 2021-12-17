using System.ComponentModel.DataAnnotations;

namespace PhamVanNhan441.Models
{
    public class CompanyPVN441
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã")]
        public string CompanyId { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string CompanyName { get; set; }
    }
}