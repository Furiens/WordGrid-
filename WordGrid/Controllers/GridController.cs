using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordGrid.Models;

namespace WordGrid.Controllers
{
    public class GridController : Controller
    {
        private readonly IGridCharRepository _repository;

        public GridController(IGridCharRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(new GridViewModel(100, 100, _repository.GridChars));
        }

        [HttpPost]
        public GridChar Advance(int id)
        {
            var gc = _repository.GridChars.FirstOrDefault(ch => ch.Id == id);
            if (gc == null)
                throw new HttpException(HttpStatusCode.NotFound);
            gc.Advance();
            _repository.Save();
            return gc;
        }
    }
}