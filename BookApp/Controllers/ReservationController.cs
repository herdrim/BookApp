using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Bll.Services.Books;
using BookApp.Bll.Services.Reservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IBookService bookService, IReservationService reservationService, ILogger<ReservationController> logger)
        {
            _bookService = bookService;
            _reservationService = reservationService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(Guid bookId)
        {
            try
            {
                var reservation = await _reservationService.GetAllReservationsByBookId(bookId);
                ViewBag.BookId = bookId;
                return View(reservation);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error during getting reservations");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(Guid id)
        {
            try
            {
                await _bookService.ReserveBook(id, User.Identity.Name);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during making reservation");
            }
                
            return RedirectToAction("Index", "Book");
        }
    }
}
