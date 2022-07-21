﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.DTO;
using MongoDB.Models;
using MongoDB.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IList<Book>>> Get()
        {
            var books = await _bookService.GetAsync();
            if (books == null)
            {
                return NoContent();
            }

            return Ok(books);
        }

        /// <summary>
        /// 调用方法 http://localhost:14761/Book/62d8fc14fdccfc7acf7e6162
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> Create(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.CreateAsync(book);
            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, bookDto);
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(string id, UpdateBookDto bookDto)
        {
            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, book);

            await _bookService.UpdateAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(string id)
        {
            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookService.RemoveAsync(id);
            return Ok();
        }
    }
}
