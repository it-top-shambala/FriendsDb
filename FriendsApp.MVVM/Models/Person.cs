namespace FriendsApp.MVVM.Models;

public class Person : NotifyPropertyChanged
{
    private int _id;
    public int Id
    {
        get => _id;
        /*set
        {
            if (value == _id) return;

            _id = value;
            OnPropertyChanged();
        }*/
        set => SetField(ref _id, value);
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    private string _firstName;
    public string FirstName
    {
        get => _firstName; 
        set => SetField(ref _firstName, value);
    }

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get => _dateOfBirth; 
        set => SetField(ref _dateOfBirth, value);
    }
}