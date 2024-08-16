using BasarsoftInternship.Entities;
using Npgsql;

namespace BasarsoftInternship.Services
{
    public class PointService : IPointService
    {
        private readonly string _connectionString;

        public PointService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Point> Get()
        {
            var points = new List<Point>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT id, pointx, pointy, name FROM points";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            points.Add(new Point
                            {
                                Id = (int)reader.GetInt64(0),
                                PointX = reader.GetDouble(1),
                                PointY = reader.GetDouble(2),
                                Name = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return points;
        }

        public Point Add(Point point)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO points (pointx, pointy, name) VALUES (@pointx, @pointy, @name) RETURNING id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pointx", point.PointX);
                    command.Parameters.AddWithValue("@pointy", point.PointY);
                    command.Parameters.AddWithValue("@name", point.Name);

                    point.Id = (int)command.ExecuteScalar();
                }
            }

            return point;
        }

        public Point Get(long id)
        {
            Point point = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT id, pointx, pointy, name FROM points WHERE id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            point = new Point
                            {
                                Id = (int)reader.GetInt64(0),
                                PointX = reader.GetDouble(1),
                                PointY = reader.GetDouble(2),
                                Name = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return point;
        }

        public Point Update(long id, Point point)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE points SET pointx = @pointx, pointy = @pointy, name = @name WHERE id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pointx", point.PointX);
                    command.Parameters.AddWithValue("@pointy", point.PointY);
                    command.Parameters.AddWithValue("@name", point.Name);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }

            return point;
        }

        public void Delete(long id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM points WHERE id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
