using SalesWebMvc.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public Seller()
        {

        }

        public Seller(int id, Name name, Email email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60")]
        public Name Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public Email Email { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
            
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public void AddSales(SalesRecord record)
        {
            Sales.Add(record);
        }

        public void RemoveSales(SalesRecord record)
        {
            Sales.Remove(record);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sales.Where(s => s.Date >= initialDate && s.Date <= finalDate).Sum(s => s.Ammount);
        }
    }
}
