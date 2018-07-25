using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WizardMVC.Models
{
    public class CustomerInfo
    {
        // fields that we need to collect in different wizard steps
        [Required(ErrorMessage = "{0} is required")]
        public string SoccerField { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "invalid email..")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Coach { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(2, ErrorMessage = "needs to be two chars")]
        [MinLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string SoccerBall { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string SoccerShoes { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string SoccerJersy { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string EnergyDrinks { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.CreditCard)]
        public string CardNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date)]
        public string ExpDate { get; set; }

        [Range(1000, 10000, ErrorMessage = "needs to be between 1000-10000")]
        public int CustomerPin { get; set; }

        public string TotalCost { get; set; }

    }
}