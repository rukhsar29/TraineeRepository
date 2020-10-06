﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSample.Entities;
using TrainingSample.EntityFramework;
using TrainingSample.Repository;

namespace TrainingSample.Controllers
{
    public class IndexController : Controller
    {
        IUserDetails userDetails = new UserDetailsRepository();
        // GET: Index
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var udetails = userDetails.GetUserDetails();
            PagedList<UserDetails> model = new PagedList<UserDetails>(udetails, page, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult InsertuS(UserDetails insert,string ProfilePic)
        {
            string base64 = ProfilePic.Substring(ProfilePic.IndexOf(',') + 1);
       
            byte[] chartData = Convert.FromBase64String(base64);

            Image image;
            using (var ms = new MemoryStream(chartData, 0, chartData.Length))
            {
                image = Image.FromStream(ms, true);
                
            }
            var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
            var fullPath = Path.Combine(Server.MapPath("~/Scripts/UserImages/"), randomFileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            insert.ProfilePic = randomFileName;
            if (ModelState.IsValid)
            {
                userDetails.GetInsertDetail(insert);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (var us=new TraineeEntities())
            {
                var viewModel = us.UserDetails.Where(x => x.UserId == id).FirstOrDefault();
                var viewModel1 = us.CarDetails.Where(x => x.UserId == id).ToList();
                viewModel.IsActive = false;
                //viewModel.IsActive = true;
                us.Entry(viewModel).State = EntityState.Modified;
                if (viewModel1.Count() > 0)
                    us.CarDetails.RemoveRange(viewModel1);

                us.SaveChanges();
                return RedirectToAction("Index");
            }
            
           
        }

    }
}