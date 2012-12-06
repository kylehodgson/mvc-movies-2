using System.ComponentModel.DataAnnotations;

namespace Zulu.Models
{
  public class SearchRequest
  {
    [Required]
    public int NumRows { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} characters long", MinimumLength = 3)]
    public string SearchTerm { get; set; }
  }
}