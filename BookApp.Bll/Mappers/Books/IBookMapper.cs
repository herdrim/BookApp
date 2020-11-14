using BookApp.Dal.Entities;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Bll.Mappers.Books
{
    public interface IBookMapper
    {
        Book Map(BookEntity book);
        BookEntity Map(Book book);
    }
}
