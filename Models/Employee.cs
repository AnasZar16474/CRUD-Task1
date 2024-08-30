using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        public int Id { set; get; }
        [DataType(DataType.Text)]
        [MaxLength(20)]
        [Required]
        public string Name { set; get; } = null!;
        public int Salary {  set; get; }
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; } = null!;
        [DataType(DataType.PhoneNumber)]
        public string Phone { set; get; } = null!;
        [DataType(DataType.Password)]
        public string Password { set; get; }= null!;

        public override string ToString()
        {
            return $"Id is {Id} Name is {Name} Salary is {Salary} Email is {Email} Phone is {Phone} Password is {Password}";
        }

    }

}
