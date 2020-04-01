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
        public ActionResult StartFight()
        {
            Main main = new Main();
            var conversie = Session["userID"].ToString();
            var id = Int32.Parse(conversie);
            main.SQL.getUserCurrency(id);
            main.SQL.getLVLStats(id);
            main.SQL.GetStats(id);
            main.SQL.getLVL(id);
            conversie = Session["statsHealth"].ToString();
            main.Fight.PlayerHealth = Int32.Parse(conversie);
            conversie = Session["lvlHealth"].ToString();
            main.Fight.LevelHealth = Int32.Parse(conversie);
            conversie = Session["statsDamage"].ToString();
            var Damage = Int32.Parse(conversie);
            conversie = Session["lvlDamage"].ToString();
            var LDamage = Int32.Parse(conversie);
            conversie = Session["lvlGoldMax"].ToString();
            main.LvlStats.level_gold_Max = Int32.Parse(conversie);
            conversie = Session["UserGold"].ToString();
            main.CurrencyModel.Currency_Gold = Int32.Parse(conversie);
            conversie = Session["levelUser"].ToString();
            main.UserLvlModel.Level_User = Int32.Parse(conversie);
            conversie = Session["statsStrenght"].ToString();
            main.StatsModel.Strenght = Int32.Parse(conversie);
            conversie = Session["lvlStrenght"].ToString();
            main.LvlStats.level_Strenght = Int32.Parse(conversie);
            conversie = Session["statsAgility"].ToString();
            main.StatsModel.Agility = Int32.Parse(conversie);
            conversie = Session["lvlAgility"].ToString();
            main.LvlStats.level_Agility = Int32.Parse(conversie);
            while (main.Fight.PlayerHealth > 0 && main.Fight.LevelHealth > 0)
            {
                Random r = new Random();
                main.Fight.PlayerDamage = r.Next(Damage - 5, Damage + 5)+(main.StatsModel.Strenght * 10);
                main.Fight.LevelDamage = r.Next(LDamage - 5, LDamage + 5)+ (main.LvlStats.level_Strenght * 10);
                main.Fight.fightdet[main.Fight.Phases]="Your Health:" + main.Fight.PlayerHealth;
                main.Fight.Phases++;
                main.Fight.fightdet[main.Fight.Phases]="Level Health:" + main.Fight.LevelHealth;
                main.Fight.Phases++;
                main.Fight.LevelHealth = main.Fight.LevelHealth - main.Fight.PlayerDamage;
                main.Fight.fightdet[main.Fight.Phases] = "You deal " + main.Fight.PlayerDamage + " damage";
                main.Fight.Phases++;
                while (main.StatsModel.Agility > main.LvlStats.level_Agility * 4 && main.Fight.LevelHealth > 0)
                {
                    main.Fight.LevelHealth = main.Fight.LevelHealth - main.Fight.PlayerDamage;
                    main.Fight.fightdet[main.Fight.Phases] = "You deal " + main.Fight.PlayerDamage + " damage";
                    main.Fight.Phases++;
                    main.StatsModel.Agility = main.StatsModel.Agility / 4;
                }              
                main.Fight.PlayerHealth = main.Fight.PlayerHealth - main.Fight.LevelDamage;
                main.Fight.fightdet[main.Fight.Phases] = "Lose " + main.Fight.LevelDamage + " health";
                main.Fight.Phases++;
            }
            if (main.Fight.LevelHealth <= 0)
            {
                main.Fight.textMessage = "You won";
                User userModel = new User();
                using (GrindEntities dbModel = new GrindEntities())
                {
                    var entityToUpdate = dbModel.Currencies.Where(el => el.Currency_User == id).FirstOrDefault();
                    if (entityToUpdate != null)
                    {
                        entityToUpdate.Currency_Gold = main.CurrencyModel.Currency_Gold + main.LvlStats.level_gold_Max;
                        dbModel.SaveChanges();
                    }
                    var entityToUpdate2 = dbModel.UserLvls.Where(el => el.Level_User_ID == id).FirstOrDefault();
                    if (entityToUpdate2 != null)
                    {
                        entityToUpdate2.Level_User = main.UserLvlModel.Level_User + 1;
                        dbModel.SaveChanges();
                    }
                }
                return PartialView("FightDetails", main);
            }
            else
            {
                main.Fight.textMessage = "You lost";
                return PartialView("FightDetails",main);
            }
        }
    }
}