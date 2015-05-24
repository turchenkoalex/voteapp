using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteApp.DAL
{
    public class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VotingId { get; set; }

        public string Title { get; set; }

        [ConcurrencyCheck]
        public int VoteCount { get; set; }
    }
}