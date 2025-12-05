using GamingOrganization.API.Entities;
using GammingOrganization.Communication.Requests;
using GammingOrganization.Communication.Responses;
using GammingOrganization.Communication.Responses.User;
using System.Xml.Linq;

namespace GamingOrganization.API.UseCases.Users.GetAll
{
    public class GetAllUsersUseCase
    {
        public ResponseAllUserJson Execute()
        {
            var users = new List<User>{
                new User { Name = "Algum",Email = "algum@gmail.com", Id =  Guid.Parse("73d85bb2-3456-4ab7-9005-1a410fa6dbc7")},
                new User { Name = "Algum", Email = "algum@gmail.com", Id = Guid.Parse("33ce9e0b-c31a-465b-8d53-31d4641487d8")}
            };
            var response = new ResponseAllUserJson
            {
                Users = users.Select(u => new ResponseShortUserJson
                {
                    Name = u.Name,
                    Id = u.Id
                }).ToList(),
            };
            return response; 
        }
    }
}
