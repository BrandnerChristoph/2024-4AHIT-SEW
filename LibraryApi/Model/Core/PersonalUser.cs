using Microsoft.AspNetCore.Identity;

namespace LibraryApi.Model.Core
{
    public class PersonalUser : IdentityUser
    {
        // Erweiterung der IdentityUser Klasse um ein Attribut Schulklasse
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
