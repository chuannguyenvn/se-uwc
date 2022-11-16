using System;

public class StaffData
{
    public string ID { get; set; }

    public string Name { get; set; }
    public string Photo { get; set; }

    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string HomeAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Nationality { get; set; }

    public DateTime HiredOn { get; set; }
    public Role Role { get; set; }
    public int Salary { get; set; }


    public StaffData(string id, string name, string photo, Gender gender, DateTime dateOfBirth,
        string homeAddress, string phoneNumber, string nationality, DateTime hiredOn, Role role,
        int salary)
    {
        ID = id;
        Name = name;
        Photo = photo;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        HomeAddress = homeAddress;
        PhoneNumber = phoneNumber;
        Nationality = nationality;
        HiredOn = hiredOn;
        Role = role;
        Salary = salary;
    }

    public override string ToString()
    {
        return "ID: " + ID + " | " + "Name: " + Name + " | " + "Photo: " + Photo + " | " + "Gender: " +
               Gender + " | " + "DateOfBirth: " + DateOfBirth + " | " + "HomeAddress: " + HomeAddress +
               " | " + "PhoneNumber: " + PhoneNumber + " | " + "Nationality: " + Nationality + " | " +
               "HiredOn: " + HiredOn + " | " + "Role: " + Role + " | " + "Salary: " + Salary + " | ";
    }
}