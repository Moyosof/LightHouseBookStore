using AutoMapper;
using LightHeight.Data;
using LightHeight.Model;
using LightHeight.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace LightHeight.Repository
{
    public class BookStoreRepository : IBookStore
    {
        private readonly AppDbContext _ctx;
        private IMapper _mapper;

        public BookStoreRepository( AppDbContext dbContext, IMapper mapper)
        {
            _ctx = dbContext;
            _mapper = mapper;
        }

        public async Task<string> AddBookToStore(BookStoreDTO bookStoreDTO)
        {
            try
            { 
                var book = _mapper.Map<BookStore>(bookStoreDTO);
                _ctx.BookStores.Add(book);
                await _ctx.SaveChangesAsync();

                return "Book Added successfully";
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            

        }

        public async Task<BookStore> GetProductById(int BookId)
        {
           BookStore bookStore = await _ctx.BookStores.Where(x => x.BookId  == BookId).FirstOrDefaultAsync();
            return bookStore;
        }

        public async Task<IEnumerable<BookStore>> GetProducts()
        {
            IEnumerable<BookStore> bookStores = await _ctx.BookStores.ToListAsync();
            return bookStores;
        }

        //public async Task<BookStoreDTO> PlaceOrder(int BookId, int quantity)
        //{
        //    BookStore bookStore = await _ctx.BookStores.FindAsync(BookId);
        //    if(bookStore == null)
        //    {
        //        return null;
        //    }

        //    var Bookstore = new BookStore
        //    {
        //        BookID = BookId,
        //        Quantity = quantity,
        //        TotalPrice = bookStore.Price * quantity,
        //    };
        //    _ctx.BookStores.Add(Bookstore);
        //    await _ctx.SaveChangesAsync();

        //    return _mapper.Map<BookStoreDTO>(Bookstore);
        //}
    }
}
