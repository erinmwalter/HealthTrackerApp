using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace HealthTracker.Models
{
    public class MeasurementDAL
    {
        //Create
        public void CreateMeasurement(Measurement m)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into measurements values(0, '{m.MeasDate.ToString("yyyy-MM-dd")}', {m.Weight}, {m.Waist}," +
                    $"{m.Chest}, {m.Fupa}, {m.Hip}, {m.Arm}, {m.Leg}, \"{m.Notes}\", {m.UserId})";
                connect.Open();
                connect.Query<Measurement>(sql);
                connect.Close();
            }

        }

        //read list by userId
        public List<Measurement> GetMeasurementsByUserId(int userId)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from measurements where userId={userId}";
                connect.Open();
                List<Measurement> m = connect.Query<Measurement>(sql).ToList();
                connect.Close();
                return m;
            }

        }

        //update
        public void UpdateMeasurement(Measurement m)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update measurements set measDate='{m.MeasDate.ToString("yyyy-MM-dd")}', weight={m.Weight}, waist={m.Waist}," +
                    $"chest={m.Chest}, fupa={m.Fupa}, hip={m.Hip}, arm={m.Arm}, leg={m.Leg}, notes=\"{m.Notes}\" where measId={m.MeasId}";
                connect.Open();
                connect.Query<Measurement>(sql);
                connect.Close();
            }

        }

        //delete
        public void DeleteMeasurement(int measId) 
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"delete from measurements where measId={measId}";
                connect.Open();
                connect.Query<Measurement>(sql);
                connect.Close();
            }
        }
    }
}
