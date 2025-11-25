using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.DataAccess
{
    public class databaseHelper
    {

        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=true";


        public bool testConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("The database is connected and working");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }

        }


        public members getMemberByUsername(string username)
        {
            //List<members> list= new List<members>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM members WHERE Username=@Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int memberId = (int)reader["MemberId"];
                            string passwordHash = reader["PasswordHash"].ToString();
                            string role = reader["Role"].ToString();

                            members m = new members(memberId, username, passwordHash, role);
                            return m;
                        }

                    }
                }



            }
            return null;
        }



        public List<books> viewAllBooks()
        {
            List<books> list = new List<books>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * FROM Books";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bookId = (int)reader["BookId"];
                            string bookTitle = reader["Title"].ToString();
                            string genre = reader["Genre"].ToString();
                            string condition = reader["Condition"].ToString();
                            bool isBorrowed = reader["IsBorrowed"] != DBNull.Value && (bool)reader["IsBorrowed"];

                            books b = new books(bookId, bookTitle, genre, condition, isBorrowed);
                            list.Add(b);
                        }
                    }
                }

                return list;
            }
        }

        public bool InsertNewBook(string title, string genre, string condition)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Books(Title,Genre,Condition,IsBorrowed) VALUES(@Title,@Genre,@Condition,@IsBorrowed)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Condition", condition);
                    cmd.Parameters.AddWithValue("@IsBorrowed", false);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }

        public List<loans> viewAllLoans()
        {
            List<loans> list = new List<loans>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * FROM Loans";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int LoanId = (int)reader["LoanId"];
                            int memberId = (int)reader["MemberId"];
                            int bookId = (int)reader["BookId"];
                            DateTime BorrowDate = (DateTime)reader["BorrowDate"];
                            DateTime DueDate = (DateTime)reader["DueDate"];

                            // Handle possible NULL ReturnDate in DB
                            DateTime returnDate = reader["ReturnDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReturnDate"];

                            loans l = new loans(LoanId, memberId, bookId, BorrowDate, DueDate, returnDate);
                            list.Add(l);
                        }
                    }
                }

                return list;
            }
        }

        public bool updateBooK(int bookId, string title, string genre, string condition)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Books SET Title=@Title,Genre=@Genre,Condition=@Condition WHERE BookId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", bookId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Condition", condition);

                    int affectectRows = cmd.ExecuteNonQuery();
                    return affectectRows > 0;
                }
            }
        }

        public bool DeleteABook(int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Books WHERE BookId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", bookId);

                    int affectectRows = cmd.ExecuteNonQuery();
                    return affectectRows > 0;
                }
            }
        }



        public bool ReturnBook(int bookId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {

                    string bookquery = "UPDATE Books SET IsBorrowed=@Borrowed WHERE BookID=@id";
                    using (SqlCommand cmd1 = new SqlCommand(bookquery, conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@id", bookId);
                        cmd1.Parameters.AddWithValue("@Borrowed", 0);
                        cmd1.ExecuteNonQuery();
                    }

                    string loanQuery = "UPDATE loans SET ReturnDate=@ReturnDate WHERE BookId=@bookId";
                    using (SqlCommand cmd2 = new SqlCommand(loanQuery, conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@bookId", bookId);
                        cmd2.ExecuteNonQuery();
                    }
                    trans.Commit();

                    return true;



                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                    return false;

                }


            }
        }

        public bool BorrowBook(int bookId, int memberId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {

                    string bookquery = "UPDATE Books SET IsBorrowed=@Borrowed WHERE BookID=@id";
                    using (SqlCommand cmd1 = new SqlCommand(bookquery, conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@id", bookId);
                        cmd1.Parameters.AddWithValue("@Borrowed", 1);
                        cmd1.ExecuteNonQuery();
                    }

                    string loanQuery = "INSERT INTO Loans(MemberId,BookId,BorrowDate,DueDate,ReturnDate) VALUES (@MemberId,@BookId,@BorrowDate,@DueDate,@ReturnDate)";
                    using (SqlCommand cmd2 = new SqlCommand(loanQuery, conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@MemberId", memberId);
                        cmd2.Parameters.AddWithValue("@BookId", bookId);
                        cmd2.Parameters.AddWithValue("@BorrowDate", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(14));
                        cmd2.Parameters.AddWithValue("@ReturnDate", DBNull.Value);
                        cmd2.ExecuteNonQuery();
                    }
                    trans.Commit();

                    return true;



                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                    return false;

                }


            }
        }
    }

}
