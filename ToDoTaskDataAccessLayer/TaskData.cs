using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ToDoTaskModels;

namespace ToDoTaskDataAccessLayer
{
    public class TaskData
    {
        static string _ConnectionString = ConfigurationManager.ConnectionStrings["ToDoDb"]?.ConnectionString
                                          ?? throw new InvalidOperationException("Connection string 'ToDoDb' is not configured.");


        public static List<TaskDTO> GetAllTasks()
        {
            var AllTasksList = new List<TaskDTO>();
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllTasks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AllTasksList.Add(
                            new TaskDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("TaskID")),
                                    reader.GetString(reader.GetOrdinal("Title")),
                                    reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                                    reader.GetDateTime(reader.GetOrdinal("DeadLine")),
                                    (TaskDTO.enPriority)reader.GetInt32(reader.GetOrdinal("Priority")),
                                    (TaskDTO.enStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                )

                            );
                        }
                    }
                }
            }

            return AllTasksList;
        }

        public static TaskDTO GetTaskByID(int ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetTaskByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskID", ID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TaskDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("TaskID")),
                                    reader.GetString(reader.GetOrdinal("Title")),
                                    reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                                    reader.GetDateTime(reader.GetOrdinal("DeadLine")),
                                    (TaskDTO.enPriority)reader.GetInt32(reader.GetOrdinal("Priority")),
                                    (TaskDTO.enStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                );
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static int AddNewTask(TaskDTO task)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddNewTask", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@DeadLine", task.DeadLine);
                    cmd.Parameters.AddWithValue("@Priority", (int)task.Priority);
                    cmd.Parameters.AddWithValue("@Status", (int)task.Status);
                    cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);

                    var OutputIdParameter = new SqlParameter("@NewTaskID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(OutputIdParameter);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)OutputIdParameter.Value;

                }
            }
        }

        public static bool UpdateTask(TaskDTO task)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTask", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Description", task.Description);
                        cmd.Parameters.AddWithValue("@DeadLine", task.DeadLine);
                        cmd.Parameters.AddWithValue("@Priority", (int)task.Priority);
                        cmd.Parameters.AddWithValue("@Status", (int)task.Status);
                        cmd.Parameters.AddWithValue("@TaskID", task.ID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the SQL-specific error
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Log any other general errors
                Console.WriteLine("Unexpected Error: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteTask(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteTask", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskID", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the SQL-specific error
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Log any other general errors
                Console.WriteLine("Unexpected Error: " + ex.Message);
                return false;
            }
        }


        public static bool UpdateStatus(int taskid, int Status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateStatus", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskID", taskid);
                        cmd.Parameters.AddWithValue("@Status", Status);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;

                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the SQL-specific error
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Log any other general errors
                Console.WriteLine("Unexpected Error: " + ex.Message);
                return false;
            }
        }

    }

}
