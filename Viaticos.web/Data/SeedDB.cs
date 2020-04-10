using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Viaticos.web.Data.Entities;
using Viaticos.web.Helpers;

namespace Viaticos.web.Data
{
    public class SeedDB
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010", "Jonathan", "Ospina", "jonathanospinac@gmail.com", "311 392 6724", "Calle 10", "Admin");
            var employee = await CheckUserAsync("2020", "Andres", "Cordoba", "killerffxv@gmail.com", "3022340789", "Carrera 51", "Employee");

            await CheckCountryAsync();
            await CheckCityAsync();
            await CheckEmployeeAsync(employee);
            await CheckManagerAsync(manager);
            await CheckTripAsync();

        }

        private async Task CheckCountryAsync()
        {
            if (!_dataContext.Countries.Any())
            {
                AddCountry("Colombia");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddCountry(string name)
        {
            _dataContext.Countries.Add(new Country
            {
                Name = name
            });
        }

        private async Task CheckCityAsync()
        {
            var country = _dataContext.Countries.FirstOrDefault();

            if (!_dataContext.Cities.Any())
            {
                AddCity("Medellin", country);
                AddCity("Cali", country);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddCity(string namecity, Country country)
        {
            _dataContext.Cities.Add(new City {
                
                Name=namecity,
                Country=country

            });

        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Employee");
        }
        private async Task<User> CheckUserAsync(string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckEmployeeAsync(User user)
        {
            if (!_dataContext.Employees.Any())
            {
                _dataContext.Employees.Add(new Employee { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckTripAsync()
        {
            var employee = _dataContext.Employees.FirstOrDefault();
            var city = _dataContext.Cities.FirstOrDefault();

            if (!_dataContext.Trips.Any())

            {
                AddTrip(employee, city, 300000);
                await _dataContext.SaveChangesAsync();
            }

        }

        private void AddTrip(Employee employee, City city, double cost)
        {
            _dataContext.Trips.Add(new Trip { 
            
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10),
                City = city,
                Employee = employee,
                TotalAmount = cost
            });
        }
    }
}
