using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Web.Data.Entities.StackeholderEntities
{
    public class Stakeholder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Maker or taker")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StakeholderTypeEnum Type { get; set; }

        [Display(Name = "Type of maker")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProducerTypeEnum ProducerType { get; set; }

        [Display(Name = "Type of taker")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BuyerTypeEnum BuyerType { get; set; }

        [Required, MaxLength(255)]
        public string Organization { get; set; }

        [Required, MaxLength(255)]
        public string State { get; set; }

        [Required, MaxLength(255)]
        public string Country { get; set; }

        [Display(Name = "Number of employees")]
        public int NumberOfEmployees { get; set; }

        [Required, MaxLength(255)]
        [Display(Name = "Contact person")]
        public string ContactPerson { get; set; }

        [Required, MaxLength(255)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        [Display(Name = "Machines, equipment, etc. you have access to")]
        public string Equipment { get; set; }

        [Display(Name = "How can you help?")]
        public string HowCanYouHelp { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedUtc { get; set; }

        [Required]
        public IdentityUser IdentityUser { get; set; }
    }
}
