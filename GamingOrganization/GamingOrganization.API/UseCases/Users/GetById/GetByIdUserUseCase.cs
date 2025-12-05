using GamingOrganization.API.Entities;
using GammingOrganization.Communication.Requests;
using GammingOrganization.Communication.Responses.User;
using ProductClientHub.Exceptions.ExceptionsBase;
using System.Collections.Generic;

namespace GamingOrganization.API.UseCases.Users.GetById
{
    public class GetByIdUserUseCase
    {
        public ResponseUserJson Execute(Guid userId)
        {
            var users = new List<User>{
                new User { Name = "Algum",Email = "algum@gmail.com", Id =  Guid.Parse("73d85bb2-3456-4ab7-9005-1a410fa6dbc7")},
                new User { Name = "Algum", Email = "algum@gmail.com", Id = Guid.Parse("33ce9e0b-c31a-465b-8d53-31d4641487d8")}
            };

            var entity = users.FirstOrDefault(User => User.Id == userId);
            if (entity == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            return new ResponseUserJson
            {
                Id = userId,
                Name = entity.Name,
                Email = entity.Email,
            };
        }
            
    }
}
