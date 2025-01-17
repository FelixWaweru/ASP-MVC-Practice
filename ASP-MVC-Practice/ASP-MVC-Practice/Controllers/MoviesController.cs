﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_Practice.Models;
using ASP_MVC_Practice.ViewModels;

namespace ASP_MVC_Practice.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        // This is the controller used to generate a view with Movie model data
        // ActionReslult is used to generate "return View(movie);"
        public ActionResult Random()
        {
            // For the sake of this project we will use inline data values and not a db
            var movie = new Movie() { Name = "Cobra Squad"};
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
                

            return View(viewModel);
        }

        // The int id is used by the RouteConfig to assign an id to the action
        public ActionResult Edit(int id)
        {
            return Content("id= " + id);
        }

        // We add the ? after the variable type to make it nullable
        // We dont add it to the string variable since strings are nullable
        // Page index is the page that will be displayed i.e page 1 of 20
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            // if pageIndex is null we will just show the first page of results
            if (!pageIndex.HasValue)
                pageIndex = 1;
            // Used to sort the results by name
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageindex={0}&sortBy = {1}", pageIndex, sortBy));
        }

        // Attribute routing used to create dynamic attributes
        // The regex is a regular expression
        // Range is a constraint used to set conditions
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            // returns movies within a specific month and year 
            return Content(year + "/" + month);
        }
    }
}