using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class MembershipType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MembershipTypeId { get; set; }
    public Description Description { get; set; }
    public bool IsRecurring { get; set; }
}

public enum Description
{
    Weekly, 
    Monthly, 
    Yearly
};