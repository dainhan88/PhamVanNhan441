using System;
using System.ComponentModel.DataAnnotations;

namespace PhamVanNhan441.Models
{
    public class PVN0441
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã")]
        public string PVNID { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên")]
        [Required]
        public string PVNName { get; set; }

        [Display(Name = "Pham Van Nhan Gender")]
        [Required]
        public Boolean PVNGender  { get; set; }
    }
}