using System.Collections.ObjectModel;
using System.Windows;
using FriendsApp.MVVM.Mappers;
using FriendsApp.MVVM.Models;
using AppContext = FriendsApp.BL.AppContext;

namespace FriendsApp.MVVM.WindowModels;

public class MainWindowWindowModel : BaseWindowModel
{
    #region Properties
    
    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    private string? _firstName;
    public string? FirstName
    {
        get => _firstName; 
        set => SetField(ref _firstName, value);
    }

    private DateTime? _dateOfBirth;
    public DateTime? DateOfBirth
    {
        get => _dateOfBirth; 
        set => SetField(ref _dateOfBirth, value);
    }

    private Person? _selectedPerson;
    public Person? SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            if (!SetField(ref _selectedPerson, value)) return;
            
            LastName = value?.LastName;
            FirstName = value?.FirstName;
            DateOfBirth = value?.DateOfBirth;
        }
    }

    public ObservableCollection<Person> Persons { get; set; }

    #endregion

    #region Commands

    public LambdaCommand CommandSave { get; set; }
    public LambdaCommand CommandClear { get; set; }

    #endregion

    public MainWindowWindowModel()
    {
        var context = new AppContext();
        var persons = context
            .GetAllFriends()
            .Select(Mapper.MapPersonBLToPerson);

        Persons = new ObservableCollection<Person>(persons);

        CommandClear = new LambdaCommand(
            execute: _ =>
            {
                LastName = null;
                FirstName = null;
                DateOfBirth = null;
            },
            canExecute: _ => LastName is not null || FirstName is not null || DateOfBirth is not null);

        CommandSave = new LambdaCommand(
            execute: _ =>
            {
                if (SelectedPerson is null) return;

                var result = context.Update(new BL.Models.Person()
                {
                    Id = SelectedPerson.Id,
                    LastName = this.LastName!,
                    FirstName = this.FirstName!,
                    DateOfBirth = (DateTime)this.DateOfBirth!
                });

                if (result)
                {
                    MessageBox.Show("Данные успешно сохранены");
                    /*Persons = new ObservableCollection<Person>();*/
                    Persons.Clear();
                    var _persons = context
                        .GetAllFriends()
                        .Select(Mapper.MapPersonBLToPerson);
                    foreach (var p in _persons)
                    {
                        Persons.Add(p);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения данных");
                }
            },
            canExecute: _ => LastName is not null && FirstName is not null && DateOfBirth is not null
            );
    }
}