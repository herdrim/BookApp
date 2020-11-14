using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Bll.Services.Books;
using BookApp.Dto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _bookService.GetAllBooks();
                return View(books);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during getting book");
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var book = await _bookService.GetBook(id);
                return View(book);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during getting book");
                return BadRequest();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _bookService.CreateBook(book);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during creating book");                
            }
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {            
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            try
            {
                await _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during editing book");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _bookService.DeleteBook(id);                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during deleting book");                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
