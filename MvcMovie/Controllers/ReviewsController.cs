using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly MvcMovieContext _context;

        public ReviewsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Reviews
        //public async Task<IActionResult> Index()
        //{
        //    var mvcMovieContext = _context.Review.Include(r => r.Movie);
        //    return View(await mvcMovieContext.ToListAsync());
        //}

        // GET: Reviews/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Review
        //        .Include(r => r.Movie)
        //        .SingleOrDefaultAsync(m => m.ReviewID == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(review);
        //}

        // GET: Reviews/List/1009
        //public async Task<IActionResult> ReviewList(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    int id2 = id ?? default(int);

        //    var reviewContext = _context.Review.Include(r => r.Movie).Where(m => m.MovieID == id2);
        //    return View(await reviewContext.ToListAsync());
        //}

        // GET: Reviews/Create
        public IActionResult Create(int? id)
        {
            var movies = from m in _context.Movie
                         select m;

            foreach (var item in movies)
            {
                if (item.ID == id)
                {
                    ViewData["mTitle"] = item.Title;
                    ViewData["mID"] = id;
                }
            }
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieReview,Name,MovieID")] Review review, int? id)
        {
            // review.MovieID = id ?? default(int);
            if (ModelState.IsValid)
            {
                review.MovieID = (int) id;
                _context.Add(review);

                ViewData["mID"] = review.MovieID;
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Movies", new { id = review.MovieID });
            }
            // ViewData["MovieID"] = new SelectList(_context.Movie, "ID", "Title", review.MovieID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["mID"] = review.MovieID;

            var movies = from m in _context.Movie
                         select m;

            foreach (var item in movies)
            {
                if(item.ID == review.MovieID)
                {
                    Console.WriteLine("EDIT ITEM ID: " + item.ID);
                    Console.WriteLine("EDIT MOVIE ID: " + review.MovieID);
                    Console.WriteLine("EDIT TITLE: " + item.Title);
                    ViewData["mTitle"] = item.Title;
                }
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MovieReview,MovieID")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new { id = review.MovieID });
            }
            //ViewData["MovieID"] = new SelectList(_context.Movie, "ID", "Title", review.MovieID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                // .Include(r => r.Movie)
                .SingleOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }
            else
            {
                var movies = from m in _context.Movie
                             select m; 

                foreach (var item in movies)
                {
                    if(item.ID == review.MovieID)
                    {
                        ViewData["mTitle"] = item.Title;
                        ViewData["mID"] = item.ID;
                    }
                }
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.ReviewID == id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Movies", new { id = review.MovieID });
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewID == id);
        }
    }
}
