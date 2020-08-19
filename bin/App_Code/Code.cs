using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace MyStudentApp.App_Code
{
    public class Code
    {
        public string Error;
        public string Error_Update;

      

     
        public string StudentInfo(string name, string surname, string age, string ID)
        {
            
            string qry = "Insert Into STUDENT (Student_Name,Student_Surname,Age,Created_Date,Student_ID) values ('" + name + "','" + surname + "'," + Convert.ToInt32(age) + ",'" + DateTime.Now + "','"+ Convert.ToInt32(ID) + "');";

            string connectionString = WebConfigurationManager.ConnectionStrings["STUDENTConnectionString"].ConnectionString; 
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                conn.Open();
                SqlCommand conncommand = new SqlCommand(qry, conn); 
                conncommand.ExecuteNonQuery(); 
                Error = "Saved Successfully!";

            }
            catch (Exception ex)  
            {
                Error = "Error occured : Connection " + ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Error;
        }

        public string StudentInfo_Update(string Student_ID, string name, string surname, string age)
        {

            string qry = "Update STUDENT Set Student_Name = '" + name + "',Student_Surname = '" + surname + "',Age = " + Convert.ToInt32(age) + " where Student_ID = " + Convert.ToInt32(Student_ID);

            string connectionString = WebConfigurationManager.ConnectionStrings["STUDENTConnectionString"].ConnectionString; //Connection Initialization
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                conn.Open();
                SqlCommand conncommand = new SqlCommand(qry, conn); //Setup Sql Query
                conncommand.ExecuteNonQuery(); //Execute SQL
                Error_Update = "Updated Successfully!";

            }
            catch (Exception ex)  //Error catch and insert into variable error
            {
                Error_Update = "Error occured : Connection " + ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Error_Update;
        }


       
        
        public string Student_Delete(string Student_ID)
        {

            string qry = "Delete  from  STUDENT where Student_ID = " + Convert.ToInt32(Student_ID);

            string connectionString = WebConfigurationManager.ConnectionStrings["STUDENTConnectionString"].ConnectionString; 
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                conn.Open();
                SqlCommand conncommand = new SqlCommand(qry, conn); 
                conncommand.ExecuteNonQuery(); 
                Error_Update = "Record Deleted Successfully!";

            }
            catch (Exception ex)  
            {
                Error_Update = "Error occured : Connection " + ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Error_Update;
        }



    }
}