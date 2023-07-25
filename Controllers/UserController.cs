using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CRUDMVC.Models;
using CRUDMVC.Repository; 

namespace CRUDMVC.Controllers
{
    public class UserController : Controller
    {
        DAL dal = new DAL();
        // GET: User
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(dal.GetDataList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(dal.GetDataList().Find(ur=>ur.Id == id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User ur)
        {
            try
            {
                // TODO: Add insert logic here
                if (dal.InsertData(ur))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.Id == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User ur)
        {
            try
            {
                // TODO: Add update logic here
                if (dal.UpdateData(ur))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.Id == id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User ur)
        {
            try
            {
                // TODO: Add delete logic here
                if (dal.DeleteData(ur))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
