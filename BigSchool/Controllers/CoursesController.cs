﻿using BigSchool.Models;
using BigSchool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BigSchool.ViewModels;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
     

        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
       [Authorize]
       [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseviewModel
            {
               categories = _dbContext.Categories.ToList(),
                Heading = "Add Course"
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseviewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
 /*   [Authorize]
    public ActiinResult Attending()
    {
        var userId = User.Identity.GetUserId();
        var courses = _dbContext.Attendances
            .Where(a => a.AttendeeId == userId)
            .Select(a => a.Course)
            .Include(l => l.Lecturer)
            .Include(l => l.Category)
            .ToList();
        var viewModel = new CoursesViewModel
        {
            UpcommingCourses = courses,
            ShowAction = User.Identity.IsAuthenticated
        };
        return View(viewModel);
    }
    [Authorize]
    public ActionResult Mine()
    {
        var userId = User.Identity.GetUserId();
        var courses = _dbContext.Courses
            .Where(c => c.LecturerId == userId && c.DateTime > DateTime.Now)
            .Include(l => l.Lecturer)
            .include(c => c.Category)
            .Tolist();
        return View(courses);
    }
    [Authorize]
    public ActionResult Edit(innt id)
    {
        var userId = User.Identity.GetUserId();
        var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);

        var viewModel = new CourseViewModel
        {
            Categories = _dbContext.Categories.Tolist(),
            Date = course.DateTime.ToString("dd/MM/yyyy"),
            Time = course.DateTime.ToString("HH:mm"),
            Category = course.CategoryId,
            Place = course.Place,
            Heading = "Edit Course",
            Id = course.Id
        };
        return View("Create", viewModel);
    }
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update (CourseviewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = _dbContext.Categories.ToList();
            return View("Create", viewModel);
        }
        var userId = User.Identity.GetUserId();
        var course = _dbContext.Courses.Single(c => c.Id == viewModel.Id && c.LecturerId == userId);
        course.Place = viewModel.Place;
        course.DateTime = viewModel.GetDateTime();
        course.CategoryId = viewModel.Category;

        _dbContext.SaveChanges();
        return RedirectToAction("Index", "Home");
    }*/
}