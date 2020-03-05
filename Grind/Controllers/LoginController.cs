using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grind;
using Grind.Models;

namespace Grind.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            Main main = new Main();
            return View(main);
        }

        [HttpPost]
        public ActionResult Index(User userModel)
        {
            Main main = new Main();
            using (GrindEntities dbModel = new GrindEntities())
            {
                if (dbModel.Users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "User already exist.";
                    return View("Index", main);
                }
                Stat stats = new Stat()
                {
                    Health = 100,
                    Strenght = 0,
                    Agility = 0,
                    Dodge = 0,
                    Critical_Chance = 0,
                    Armour = 0,
                    Damage = 10,
                    Stats_User = userModel.User_ID
                };
                UserLvl lvl = new UserLvl()
                {
                    Level_User=1,
                    Level_User_ID= userModel.User_ID
                };
                dbModel.Users.Add(userModel);
                dbModel.Stats.Add(stats);
                dbModel.UserLvls.Add(lvl);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Registration Successful";
            return View("Index", new Main());
        }

        [HttpPost]
        public ActionResult Login(Grind.User userModel)
        {
            Main main = new Main();
            using (GrindEntities dbModel = new GrindEntities())
            {
                var userDetails = dbModel.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    main.UserModel.LoginError = "Invalid User or Password!";
                    return View("Index", userModel);
                }
                else
                {
                    main.UserModel.Username = userDetails.Username;
                    main.UserModel.User_ID = userDetails.User_ID;
                    main.SQL.GetStats(main.UserModel.User_ID);
                    main.SQL.getLVL(main.UserModel.User_ID);
                    main.SQL.getLVLStats(main.UserModel.User_ID);
                    Session["userID"] = main.UserModel.User_ID;
                    Session["userName"] = main.UserModel.Username;
                    return RedirectToAction("Index", "MainPage");
                }
            }
        }
        public ActionResult Logout()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}