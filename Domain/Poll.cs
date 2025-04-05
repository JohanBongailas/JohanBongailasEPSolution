using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }

        // Making the string properties non-nullable
        public string Title { get; set; } = string.Empty!;
        public string Option1Text { get; set; } = string.Empty!;
        public string Option2Text { get; set; } = string.Empty!;
        public string Option3Text { get; set; } = string.Empty!;

        public int Option1VotesCount { get; set; }
        public int Option2VotesCount { get; set; }
        public int Option3VotesCount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
