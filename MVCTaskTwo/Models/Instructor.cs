using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MVCTaskTwo.Models
{
    
    public class Instructor
    {
        public int ID { get; set; }
        [Remote(controller:"Instructor",action: "NameExist",ErrorMessage ="Name alredy Exist",AdditionalFields ="ID")]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Range(2000,1000000)]
        public double Salary { get; set; }

        //forignKeys
        [ForeignKey("Department")]
        [Display(Name ="Department ID")]
        
        public int Dept_ID { get; set; }
        
        public Department? Department { get; set; } 
     
    }
}
