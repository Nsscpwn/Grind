using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grind.Models
{
    public class FightDet
    {
        public void getFight(int Id)
        {
            Main main = new Main();
            SqlConnection con = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-4GS4D8J;Initial Catalog=Grind;Integrated Security=True"
            };
            con.Open();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "select * from Stats inner join Users on Users.User_ID=Stats.Stats_User where @id=Stats.Stats_User",
                Connection = con
            };
            cmd.Parameters.Add(new SqlParameter("@id", Id));
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var userID = rd["Stats_ID"].ToString();
                main.StatsModel.Stats_ID = Int32.Parse(userID);
                var userHealth = rd["Health"].ToString();
                main.StatsModel.Health = Int32.Parse(userHealth);
                var userStrenght = rd["Strenght"].ToString();
                main.StatsModel.Strenght = Int32.Parse(userStrenght);
                var userAgility = rd["Agility"].ToString();
                main.StatsModel.Agility = Int32.Parse(userAgility);
                var userDodge = rd["Dodge"].ToString();
                main.StatsModel.Dodge = Int32.Parse(userDodge);
                var userCritical = rd["Critical_Chance"].ToString();
                main.StatsModel.Critical_Chance = Int32.Parse(userCritical);
                var userStatsUser = rd["Stats_User"].ToString();
                main.StatsModel.Stats_User = Int32.Parse(userStatsUser);
                var userDamage = rd["Damage"].ToString();
                main.StatsModel.Damage = Int32.Parse(userDamage);
                var userArmour = rd["Armour"].ToString();
                main.StatsModel.Armour = Int32.Parse(userArmour);
                HttpContext.Current.Session["statsHealth"] = main.StatsModel.Health;
                HttpContext.Current.Session["statsAgility"] = main.StatsModel.Agility;
                HttpContext.Current.Session["statsStrenght"] = main.StatsModel.Strenght;
                HttpContext.Current.Session["statsDodge"] = main.StatsModel.Dodge;
                HttpContext.Current.Session["statsCritical"] = main.StatsModel.Critical_Chance;
                HttpContext.Current.Session["statsUser"] = main.StatsModel.Stats_User;
                HttpContext.Current.Session["statsArmour"] = main.StatsModel.Armour;
                HttpContext.Current.Session["statsDamage"] = main.StatsModel.Damage;
                HttpContext.Current.Session["statsID"] = main.StatsModel.Stats_ID;
            }
            con.Close();
            rd.Close();
        }
    }
}
