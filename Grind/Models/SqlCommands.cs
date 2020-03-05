using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grind.Models
{
    public class SqlCommands
    {
        public void GetStats(int id)
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
            cmd.Parameters.Add(new SqlParameter("@id", id));
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
                var userArmour  = rd["Armour"].ToString();
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
        public void getLVL(int id)
        {
            Main main = new Main();
            SqlConnection con = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-4GS4D8J;Initial Catalog=Grind;Integrated Security=True"
            };
            con.Open();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "select * from UserLvl inner join Users on Users.User_ID=UserLvl.Level_User_ID where @id=UserLvl.Level_User_ID",
                Connection = con
            };
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var lvl= rd["Level_User"].ToString();
                main.UserLvlModel.Level_User = Int32.Parse(lvl);
                var lvlid = rd["Level_ID"].ToString();
                main.UserLvlModel.Level_ID = Int32.Parse(lvlid);
                var lvluser = rd["User_ID"].ToString();
                main.UserLvlModel.Level_User_ID = Int32.Parse(lvluser);
                HttpContext.Current.Session["levelUser"] = main.UserLvlModel.Level_User;
                HttpContext.Current.Session["levelID"] = main.UserLvlModel.Level_ID;
                HttpContext.Current.Session["levelUserID"] = main.UserLvlModel.Level_User_ID;
            }
            con.Close();
            rd.Close();
        }
        public void getLVLStats(int id)
        {
            Main main = new Main();
            SqlConnection con = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-4GS4D8J;Initial Catalog=Grind;Integrated Security=True"
            };
            con.Open();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "select * from UserLvl inner join Users on Users.User_ID=UserLvl.Level_User_ID " +
                "                                    inner join Levels on Levels.Level_ID=UserLvl.Level_User where @id=UserLvl.Level_User_ID",
                Connection = con
            };
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
              
                var levelHealth = rd["Level_Health"].ToString();
                main.LvlStats.level_Health = Int32.Parse(levelHealth);
                var levelArmour = rd["Level_Armour"].ToString();
                main.LvlStats.level_Armour = Int32.Parse(levelArmour);
                var levelDamage = rd["Level_Damage"].ToString();
                main.LvlStats.level_Damage = Int32.Parse(levelDamage);
                var levelStrenght = rd["Level_Stenght"].ToString();
                main.LvlStats.level_Strenght = Int32.Parse(levelStrenght);
                var levelAgility = rd["Level_Agility"].ToString();
                main.LvlStats.level_Agility = Int32.Parse(levelAgility);
                var levelDodge = rd["Level_Dodge"].ToString();
                main.LvlStats.level_Dodge = Int32.Parse(levelDodge);
                var levelCritical = rd["Level_Critical_Chance"].ToString();
                main.LvlStats.level_Critical = Int32.Parse(levelCritical);
                var levelBoss = rd["Level_Boss"].ToString();
                main.LvlStats.level_Boss = Int32.Parse(levelBoss);
                var goldMin = rd["Level_Gold_Min"].ToString();
                main.LvlStats.level_Gold_Min = Int32.Parse(goldMin);
                var goldMax = rd["Level_Gold_Max"].ToString();
                main.LvlStats.level_gold_Max = Int32.Parse(goldMax);
                var statsPoint = rd["Level_Stats_Point"].ToString();
                main.LvlStats.stats_Point = Int32.Parse(statsPoint);
                var skillPint = rd["Level_Skill"].ToString();
                main.LvlStats.skill_Point = Int32.Parse(skillPint);
                HttpContext.Current.Session["lvlHealth"] = main.LvlStats.level_Health;
                HttpContext.Current.Session["lvlAgility"] = main.LvlStats.level_Agility;
                HttpContext.Current.Session["lvlStrenght"] = main.LvlStats.level_Strenght;
                HttpContext.Current.Session["lvlDodge"] = main.LvlStats.level_Dodge;
                HttpContext.Current.Session["lvlCritical"] = main.LvlStats.level_Critical;
                HttpContext.Current.Session["lvlBoss"] = main.LvlStats.level_Boss;
                HttpContext.Current.Session["lvlArmour"] = main.LvlStats.level_Armour;
                HttpContext.Current.Session["lvlDamage"] = main.LvlStats.level_Damage;
                HttpContext.Current.Session["lvlGoldMin"] = main.LvlStats.level_Gold_Min;
                HttpContext.Current.Session["lvlGoldMax"] = main.LvlStats.level_gold_Max;
                HttpContext.Current.Session["lvlStatsPoint"] = main.LvlStats.stats_Point;
                HttpContext.Current.Session["lvlSkillPoint"] = main.LvlStats.skill_Point;
            }
            con.Close();
            rd.Close();
        }
    }
}



