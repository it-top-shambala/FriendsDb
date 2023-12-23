using System.Windows;
using FriendsApp.Models;

namespace FriendsApp.Windows.FriendInfoWindow;

public partial class FriendInfoWindow : Window
{
    private readonly Person _person;
    
    public FriendInfoWindow(Person person)
    {
        _person = person;
        
        InitializeComponent();

        InputLastName.Text = _person.LastName;
        InputFirstName.Text = _person.FirstName;
        InputDateOfBirth.SelectedDate = _person.DateOfBirth;
    }
}