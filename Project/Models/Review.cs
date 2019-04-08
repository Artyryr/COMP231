using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string UserName { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string ReviewText { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public void AddUser(string userName)
        {
            UserName = userName;
        }
    }
}
