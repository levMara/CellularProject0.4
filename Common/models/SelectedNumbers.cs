using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public class SelectedNumbers
    {
        [Key]
        [ForeignKey("Package")]
        public int SelectedNumbersID { get; set; }

        [Required, MaxLength(13)]
        public string Number1 { get; set; }

        [MaxLength(13)]
        public string Number2 { get; set; }

        [MaxLength(13)]
        public string Number3 { get; set; }

        [Required]
        public virtual Package Package { get; set; }

    }
}