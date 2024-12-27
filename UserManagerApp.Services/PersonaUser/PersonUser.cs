using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagerApp.Domain.Model;
using UserManagerApp.Infrastructure;
using UserManagerApp.Services.PersonaUser.DTO;
using UserManagerApp.Services.Uitls;

namespace UserManagerApp.Services.PersonaUser
{
    public class PersonUser : IPersonUser
    {

        private readonly UserManager<UserManagerApp.Domain.Model.User> userManager;
        private readonly AppDbContext dbContext;

        public PersonUser(UserManager<UserManagerApp.Domain.Model.User> userManager, AppDbContext dbContext)
        {

            this.userManager = userManager;
            this.dbContext = dbContext;
        }


        public async Task<OperationResult> RegisterPersonUser(RegisterPersonUserDto data)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = new UserManagerApp.Domain.Model.User
                    {
                        UserName = data.UserName,
                        Email = data.Email,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = "System",
                        UpdatedBy = "System",
                        UpdatedOn = DateTime.UtcNow,
                    };

                    var result = await userManager.CreateAsync(user, data.Password);
                    if (!result.Succeeded)
                    {
                        return new OperationResult
                        {
                            IsSuccess = false,
                            ErrorMessage = $"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}"
                        };
                    }

                    var person = new Person
                    {
                        IdPerson = Guid.NewGuid(),
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Identification = data.Identification,
                        Email = data.Email,
                        IdentificationType = data.IdentificationType,
                        UserId = user.Id,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = "System",
                        UpdatedBy = "System",
                    };

                    dbContext.Persons.Add(person);
                    await dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new OperationResult
                    {
                        IsSuccess = true,
                        ErrorMessage = null
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new OperationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = $"An error occurred: {ex.Message}"
                    };
                }
            }
        }


        public List<PersonUserDto> GetAllPersons()
        {
            // Ejecuta el procedimiento almacenado y luego realiza la proyección en memoria
            return dbContext.Persons
                .FromSqlRaw("EXEC GetAllPersons")
                .AsEnumerable()  // Realiza la proyección en memoria (en el cliente)
                .Select(person => new PersonUserDto
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Identification = person.Identification,
                    Email = person.Email,
                    IdentificationType = person.IdentificationType
                })
                .ToList();
        }



    }






}
