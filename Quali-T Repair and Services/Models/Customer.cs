using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "First  Name is Required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "E-mail is Required.")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Display(Name = "User Name")]
        [StringLength(10, ErrorMessage = "Username cannot be longer than 10 characters.")]
        [Required(ErrorMessage = "Username is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [Display(Name = "Contact Number")]
        [Phone]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password need to match.")]
        [Required(ErrorMessage = "Confirm Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? MemberSince { get; set; }

        public Customer ()
        {
            MemberSince = DateTime.Now.Date;
        }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        
        [Display(Name = "Billing Address")]
        [Required(ErrorMessage = "Billing Address is Required")]
        public string BillingAddress { get; set; }
       
        public CustomerType CustomerType { get; set; }

        [ForeignKey("CustomerType")]
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

    }
}