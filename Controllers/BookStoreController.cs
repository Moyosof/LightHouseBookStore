using LightHeight.Model;
using LightHeight.Model.DTO;
using LightHeight.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightHeight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private IBookStore _bookStore;
        protected ResponseDTO _responseDTO;

        public BookStoreController(IBookStore bookStore)
        {
            _bookStore = bookStore;
            this._responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                var book = await _bookStore.GetProducts();
                _responseDTO.Result = book;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var book = await _bookStore.GetProductById(id);
                _responseDTO.Result = book; 
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDTO;
        }
        [HttpPost("add-book")]
        public async Task<ActionResult<BookStoreDTO>> AddBook([FromBody] BookStoreDTO bookStore)
        {
            try
            {
                var addedBook = await _bookStore.AddBookToStore(bookStore);

                if (addedBook == null)
                {
                    return BadRequest("Invalid book data or book could not be added.");
                }

                return Ok(addedBook);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the book.");
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> PlaceOrder([FromBody] BookStore bookStore)
        //{
        //    try
        //    {
        //        if (bookStore == null)
        //        {
        //            return NotFound("Invalid order request.");
        //        }
        //        var order = await _bookStore.PlaceOrder(bookStore.BookID, bookStore.Quantity);
        //        if (order == null)
        //        {
        //            return NotFound("Book not found.");
        //        }
        //        _responseDTO.Result = order;
        //        return Ok(_responseDTO);
        //    }
        //    catch(Exception ex)
        //    {
        //        _responseDTO.IsSuccess = false;
        //        _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
        //        return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
        //    }
        //}

    }
}
