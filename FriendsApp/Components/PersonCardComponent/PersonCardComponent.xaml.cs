using System.Windows;
using System.Windows.Controls;
using FriendsApp.Models;
using FriendsApp.Windows.FriendInfoWindow;

namespace FriendsApp.Components.PersonCardComponent;

public partial class PersonCardComponent : UserControl
{
    private readonly Person _person;
    public PersonCardComponent(Person person)
    {
        _person = person;
        
        InitializeComponent();
        
        TextPersonName.Text = _person.FullNameWitInitials;
        TextPersonAge.Text = _person.Age.ToString();
    }

    private void ButtonInfo_OnClick(object sender, RoutedEventArgs e)
    {
        new FriendInfoWindow(_person).Show();
    }
}