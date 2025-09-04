
using System.ComponentModel.DataAnnotations;

namespace asp_member_prac.Models
{
    public class Employee
    {
        [Display(Name = "員工編號")]
        public int EmpId { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string? Name { get; set; }
        [Display(Name = "性別")]
        [Required(ErrorMessage = "性別必填")]
        public string? Gender { get; set; }
        [Display(Name = "信箱")]
        [EmailAddress(ErrorMessage = "必須符合信箱格式")]
        public string? Mail { get; set; }
        [Display(Name = "薪資")]
        [Range(25000, 65000, ErrorMessage = "薪資範圍25000~65000")]
        public int? Salary { get; set; }
        [Display(Name = "雇用日期")]
        [Required(ErrorMessage = "雇用日期必填")]
        [DataType(DataType.Date)]
        public DateTime? EmploymentDate { get; set; }
    }
}