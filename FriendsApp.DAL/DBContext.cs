using FriendsApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsApp.DAL;

public class DBContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    { }
    
    
}