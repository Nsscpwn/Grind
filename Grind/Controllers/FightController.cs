using Grind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grind.Controllers
{
    public class FightController : Controller
    {
        // GET: Fight
        [HttpPost]
        public ActionResult StartFight()
        {
            var conversie = Session["userID"].ToString();
            var id = Int32.Parse(conversie);
            Main main = new Main();
            main.SQL.getLVLStats(id);
            main.SQL.GetStats(id);
            conversie = Session["statsHealth"].ToString();
            var PlayerHealth = Int32.Parse(conversie);
            conversie = Session["lvlHealth"].ToString();
            var LevelHealth = Int32.Parse(conversie);
            conversie = Session["statsDamage"].ToString();
            var PlayerDamage = Int32.Parse(conversie);
            conversie = Session["lvlDamage"].ToString();
            var LevelDamage = Int32.Parse(conversie);
            while (LevelHealth > 0 && PlayerHealth > 0)
            {
                LevelHealth = LevelHealth - PlayerDamage;
                PlayerHealth = PlayerHealth - LevelDamage;            
                     
            }
            if (LevelHealth <= 0)
            {
                main.Fight.textMessage = "You won";
                return View("../MainPage/Index");

            }
            else
            {
                main.Fight.textMessage = "You lost";
                return View("_FightDetails");
            }
        }
    }
}