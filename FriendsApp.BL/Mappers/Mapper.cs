namespace FriendsApp.BL.Mappers;

public static class Mapper
{
    public static BL.Models.Person MapPersonDALToPersonBL(DAL.Models.Person person)
    {
        return new BL.Models.Person()
        {
            Id = person.Id,
            LastName = person.LastName,
            FirstName = person.FirstName,
            DateOfBirth = person.DateOfBirth
        };
    }
}