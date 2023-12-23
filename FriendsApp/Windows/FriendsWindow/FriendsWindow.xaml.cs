using System.Windows;
using System.Windows.Input;
using FriendsApp.Components.PersonCardComponent;
using FriendsApp.Mappers;
using AppContext = FriendsApp.BL.AppContext;

namespace FriendsApp.Windows.FriendsWindow;

public partial class FriendsWindow : Window
{
    public FriendsWindow()
    {
        InitializeComponent();

        var context = new AppContext();
        var persons = context
            .GetAllFriends()
            .Select(Mapper.MapPersonBLToPerson);
        foreach (var person in persons)
        {
            Panel.Children.Add(new PersonCardComponent(person));
        }
    }

    private void CommandBinding_OnClosed(object sender, ExecutedRoutedEventArgs e)
    {
        this.Close();
    }
}