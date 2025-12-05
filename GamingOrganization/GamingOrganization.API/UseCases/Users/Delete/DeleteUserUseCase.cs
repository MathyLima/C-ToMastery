using GamingOrganization.API.Entities;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace GamingOrganization.API.UseCases.Users.Delete
{
    public class DeleteUserUseCase
    {
        public void Execute(Guid userId) {
            var users = new List<User>{
                new User { Name = "Algum",Email = "algum@gmail.com", Id =  Guid.Parse("73d85bb2-3456-4ab7-9005-1a410fa6dbc7")},
                new User { Name = "Algum", Email = "algum@gmail.com", Id = Guid.Parse("33ce9e0b-c31a-465b-8d53-31d4641487d8")}
            };

            var entity = users.FirstOrDefault(User=>User.Id == userId );

            if (entity == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }
        }
    }
}
