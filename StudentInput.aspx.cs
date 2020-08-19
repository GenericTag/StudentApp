using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MyStudentApp.App_Code;


namespace MyStudentApp
{
    public partial class StudentInput : System.Web.UI.Page

    {
        private void ClearInput() // Clear all textboxes of input 
        {
            txtID.Text = "";
            txtage.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Button2.Visible = false;
            btnSave.Visible =true;
            Button3.Visible = false;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Code SQLConnect = new Code();
            string Feedback = SQLConnect.StudentInfo(txtName.Text, txtSurname.Text, txtage.Text,txtID.Text).ToString();
            lblFeedBack.Text = Feedback;
            GridView1.DataBind();
            ClearInput();

        }

       
        
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            Code SQLConnect = new Code();
            string Feedback = SQLConnect.StudentInfo_Update(txtID.Text, txtName.Text, txtSurname.Text, txtage.Text).ToString();
            lblFeedBack.Text = Feedback;
            GridView1.DataBind();
            ClearInput();
            Button2.Visible = true;
            btnSave.Visible = true;
            Button3.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           Code SQLConnect = new Code();
            string Feedback = SQLConnect.Student_Delete(txtID.Text).ToString();
            lblFeedBack.Text = Feedback;
            GridView1.DataBind();
            ClearInput();
            Button2.Visible = false;
            btnSave.Visible = true;
            Button3.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtID.Text = GridView1.SelectedRow.Cells[5].Text;
            txtName.Text = GridView1.SelectedRow.Cells[1].Text;
            txtSurname.Text = GridView1.SelectedRow.Cells[2].Text;
            txtage.Text = GridView1.SelectedRow.Cells[3].Text;

            Button2.Visible = true;
            btnSave.Visible = false;
            Button3.Visible = true;

        }
    }
}