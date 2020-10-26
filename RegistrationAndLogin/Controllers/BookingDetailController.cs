using RegistrationAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RegistrationAndLogin.Controllers
{
    [Authorize]
    public class BookingDetailController : Controller
    {
        UserRegistrationEntities6 dbobj = new UserRegistrationEntities6();
        // GET: BookingDetail
        public ActionResult Index()
        {
            using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
            {
                List<BookingDetail> BookingDetail = new List<BookingDetail>();
                BookingDetail = dBModel.BookingDetails.ToList();
                var emailID = Session["EmailID"].ToString().ToLower();
                BookingDetail = BookingDetail.Where(c => c.EmailID.ToLower() == emailID).ToList();
                return View(BookingDetail);
            }
        }

        // GET: BookingDetail/Details/5
        public ActionResult Details(int id)
        {
            using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
            {
                return View(dBModel.BookingDetails.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // GET: BookingDetail/Create
        //  [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingDetail/Create
        [HttpPost]
        public ActionResult Create(BookingDetail bookingDetail)
        {
            try
            {
                using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
                {
                    {

                        var isExist = IsTimeExist(bookingDetail.TimeForBooking, bookingDetail.StylistName, bookingDetail.DateForBooking);
                        if (isExist)
                        {
                            ModelState.AddModelError("Time exist", "Time already exist");
                            return View(bookingDetail);
                        }
                        else
                        {
                            dBModel.BookingDetails.Add(bookingDetail);
                            dBModel.SaveChanges();
                        }
                    }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        [NonAction]
        public bool IsTimeExist(TimeSpan TimeForBooking, string StylistName, DateTime DateForBooking)
        {
            using (UserRegistrationEntities6 dc = new UserRegistrationEntities6())
            {
                var v = dc.BookingDetails.Where(a => a.TimeForBooking == TimeForBooking && a.StylistName == StylistName && a.DateForBooking == DateForBooking).FirstOrDefault();
                return v != null;
            }
        }
        // GET: BookingDetail/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
            {
                return View(dBModel.BookingDetails.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // POST: BookingDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookingDetail bookingDetail)
        {
            try
            {
                using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
                {
                    var isExist = IsTimeExist(bookingDetail.TimeForBooking, bookingDetail.StylistName, bookingDetail.DateForBooking);
                    if (isExist)
                    {
                        ModelState.AddModelError("Time exist", "Time already exist");
                        return View(bookingDetail);
                    }
                    else
                    {
                        dBModel.BookingDetails.Add(bookingDetail);
                        dBModel.SaveChanges();
                    }
                    dBModel.Entry(bookingDetail).State = EntityState.Modified;
                    dBModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingDetail/Delete/5
        public ActionResult Delete(int id)
        {
            using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
            {
                return View(dBModel.BookingDetails.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // POST: BookingDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookingDetail bookingDetail)
        {
            try
            {
                using (UserRegistrationEntities6 dBModel = new UserRegistrationEntities6())
                {
                    BookingDetail booking = dBModel.BookingDetails.Where(x => x.UserID == id).FirstOrDefault();
                    dBModel.BookingDetails.Remove(bookingDetail);
                    dBModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}