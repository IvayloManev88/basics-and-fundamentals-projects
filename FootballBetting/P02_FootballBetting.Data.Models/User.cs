

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static P02_FootballBetting.Common.EntityValidationConstants.User;

    namespace P02_FootballBetting.Data.Models
    {
        public class User
        {
            //UserId, Username, Name, Password, Email, Balance
            [Key]
            public int UserId { get; set; }

            [Required]
            [MaxLength(UserUserNameMaxLength)]
            public string Username { get; set; } = null!;

             [Required]
             [MaxLength(UserNameMaxLength)]
             public string Name { get; set; } = null!;

        [Required]
            [MaxLength(PasswordMaxLength)]
            public string Password { get; set; } = null!;


            [MaxLength(EmailMaxLength)]
            public string Email { get; set; } = null!;

            public decimal Balance { get; set; }

              public virtual ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
         }
    }

