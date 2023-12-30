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

    public bool Update(Person person)
    {
        var personDal = _db.Persons.FirstOrDefault(p => p.Id == person.Id);

        if (personDal is null) return false;
        
        var converterPerson = Mapper.MapPersonBLToPersonDAL(person);
        personDal.LastName = converterPerson.LastName;
        personDal.FirstName = converterPerson.FirstName;
        personDal.DateOfBirth = converterPerson.DateOfBirth;
        
        try
        {
            _db.SaveChanges();
        }
        catch (Exception)
        {
            return false;
        }
        
        return true;
    }
}