using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientCase
    {
        public void Execute(Guid clientId)
        {
            var dbContext = new ProductClientsHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
            if (entity is null)
                throw new NotFoundException("Produto não encontrado.");
            // Lógica para deletar o produto com o ID fornecido

            dbContext.Clients.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
