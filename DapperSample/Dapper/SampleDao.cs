using Dapper;
using DapperSample.Model;
using Npgsql;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DapperSample
{
    class SampleDapper
    {
        public static SampleDapper Instance = new SampleDapper();
        private SampleDapper() { }

        public Worker Select(string id)
        {
            var worker = new Worker();

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Npgsql"].ConnectionString))
            {
                var sql = "select * from worker where id = @id";

                worker = connection.Query<Worker>(sql, new { id}).FirstOrDefault();
            }

            return worker;
        }

        public IEnumerable<Worker> Select() {

            var workerList = new List<Worker>();

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Npgsql"].ConnectionString))
            {
                var sql = "select * from worker";

                workerList = connection.Query<Worker>(sql).ToList();
            }

            return workerList;
        }

        public int Insert(string id, string name, int age, string department)
        {
            var result = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Npgsql"].ConnectionString))
            {
                var sql = "insert into worker (id, name, age, department) values (@id, @name, @age, @department)";

                result = connection.Execute(sql, new { id, name, age, department });
            }

            return result;
        }

        public int Update(string id, int age)
        {
            var result = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Npgsql"].ConnectionString))
            {
                var sql = "update worker set age = @age where id = @id";

                result = connection.Execute(sql, new { id, age});
            }

            return result;
        }

        public int Delete(string id)
        {
            var result = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Npgsql"].ConnectionString))
            {
                var sql = "delete from worker where id = @id";

                result = connection.Execute(sql, new { id });
            }

            return result;
        }
    }
}
