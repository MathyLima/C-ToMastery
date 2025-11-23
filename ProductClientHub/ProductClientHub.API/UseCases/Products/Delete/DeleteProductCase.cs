using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductCase
    {
        public void Execute(Guid productId)
        {
            var dbContext = new ProductClientsHubDbContext();
            var entity = dbContext.Products.FirstOrDefault(product => product.Id == productId);
            if(entity is null)
                throw new NotFoundException("Produto não encontrado.");
            // Lógica para deletar o produto com o ID fornecido

            dbContext.Products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
