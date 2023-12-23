namespace FriendsApp.BL.Models;

public class Person
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FullName => $"{LastName} {FirstName}";
    public string FullNameWitInitials => $"{LastName} {FirstName[0]}.";
    
    public DateTime DateOfBirth { get; set; }
    public int Age {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}