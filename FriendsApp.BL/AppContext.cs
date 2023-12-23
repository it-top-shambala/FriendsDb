using FriendsApp.BL.Mappers;
using FriendsApp.BL.Models;
using FriendsApp.DAL;

namespace FriendsApp.BL;

public class AppContext
{
    private readonly DBContext _db;

    public AppContext()
    {
        _db = new DBContextFactory().CreateDbContext(Array.Empty<string>());
    }

    public IEnumerable<Person> GetAllFriends()
    {
        return _db.Persons
            .Select(Mapper.MapPersonDALToPersonBL)
            .ToList();
    }
}