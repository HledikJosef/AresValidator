using System.ComponentModel.DataAnnotations;

namespace AresValidator.Models
{
    public class IcoModel
    {
        [Required(ErrorMessage = "IČ je povinné.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "IČ musí mít přesně 8 číslic.")]
        public string Ico { get; set; } = string.Empty;
    }
}
