using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoVendasTCC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres")]
        [Display(Name = "Nome")]
        public String Name { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com E-Mail valido")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Aniversário")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Salário Base")]
        public double BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Department Department { get; set; }

        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
