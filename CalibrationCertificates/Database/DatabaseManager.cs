using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using CalibrationCertificates.Models;
using Npgsql;

namespace CalibrationCertificates.Database
{
    public static class DatabaseManager
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        /// <summary>
        /// Проверка логина и пароля пользователя
        /// </summary>
        public static bool CheckLogin(string username, string password)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                var count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Получить список пользователей по роли (калибровщик / главный метролог)
        /// </summary>
        public static List<User> GetUsersByRole(string role)
        {
            var list = new List<User>();
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string query = "SELECT id, username, role FROM users WHERE role = @role";

                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("role", role);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Role = reader.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения пользователей:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        /// <summary>
        /// Получить список эталонов
        /// </summary>
        public static List<Standard> GetStandards()
        {
            var list = new List<Standard>();
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string query = "SELECT id, standard_name, factory_number FROM standards";

                using var cmd = new NpgsqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Standard
                    {
                        Id = reader.GetInt32(0),
                        StandardName = reader.GetString(1),
                        FactoryNumber = reader.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения эталонов:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        /// <summary>
        /// Получить список приборов
        /// </summary>
        public static List<Device> GetDevices()
        {
            var list = new List<Device>();
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string query = "SELECT id, device_name, factory_number, inventory_number, periodicity, document_name, department FROM devices";

                using var cmd = new NpgsqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Device
                    {
                        Id = reader.GetInt32(0),
                        DeviceName = reader.GetString(1),
                        FactoryNumber = reader.GetString(2),
                        InventoryNumber = reader.GetString(3),
                        Periodicity = reader.GetInt32(4),
                        DocumentName = reader.GetString(5),
                        Department = reader.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения приборов:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        /// <summary>
        /// Вставить новый сертификат
        /// </summary>
        public static void InsertCertificate(Certificate cert)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string query = @"
                    INSERT INTO certificates 
                    (device_id, standard_id, calibrator_id, chief_metrologist_id, temperature, humidity, pressure, voltage, calibration_date)
                    VALUES 
                    (@device_id, @standard_id, @calibrator_id, @chief_metrologist_id, @temperature, @humidity, @pressure, @voltage, @calibration_date)
                ";

                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("device_id", cert.DeviceId);
                cmd.Parameters.AddWithValue("standard_id", cert.StandardId);
                cmd.Parameters.AddWithValue("calibrator_id", cert.CalibratorId);
                cmd.Parameters.AddWithValue("chief_metrologist_id", cert.ChiefMetrologistId);
                cmd.Parameters.AddWithValue("temperature", cert.Temperature);
                cmd.Parameters.AddWithValue("humidity", cert.Humidity);
                cmd.Parameters.AddWithValue("pressure", cert.Pressure);
                cmd.Parameters.AddWithValue("voltage", cert.Voltage);
                cmd.Parameters.AddWithValue("calibration_date", cert.CalibrationDate);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения сертификата:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
