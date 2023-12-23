namespace FriendsApp.Mappers;

public static class Mapper
{
    public static Models.Person MapPersonBLToPerson(BL.Models.Person person)
    {
        return new Models.Person()
        {
            Id = person.Id,
            LastName = person.LastName,
            FirstName = person.FirstName,
            DateOfBirth = person.DateOfBirth
        };
    }
}