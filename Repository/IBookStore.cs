using LightHeight.Model;
using LightHeight.Model.DTO;

namespace LightHeight.Repository
{
    public interface IBookStore
    {

        Task<IEnumerable<BookStore>> GetProducts();
        Task<BookStore> GetProductById(int BookId);
        Task<string> AddBookToStore(BookStoreDTO bookStoreDTO);

    }
}
