using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntites;
using BusinessLogic;

namespace SchoolThreeTireDemo
{
    public partial class StudentInfo : System.Web.UI.Page
    {

        StudentEntites StudentEntites = new StudentEntites();
        StudentBusinessLogic StudentBusinessLogic = new StudentBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            GridView1.DataSource = StudentBusinessLogic.GetAllStudent();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentEntites.FName = TextBox1.Text;
            StudentEntites.LName = TextBox2.Text;
            StudentEntites.Age = Convert.ToInt32(TextBox3.Text);
            StudentEntites.Sex = TextBox4.Text;
            var res = StudentBusinessLogic.StudentEntry(StudentEntites);
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = "";
            RefreshData();
        }

        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
            StudentBusinessLogic.DeleteStudent(id);
            RefreshData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
            TextBox txtFname = GridView1.Rows[e.RowIndex].FindControl("Fnametxt") as TextBox;
            TextBox txtLname = GridView1.Rows[e.RowIndex].FindControl("Lnametxt") as TextBox;
            TextBox txtAge = GridView1.Rows[e.RowIndex].FindControl("Agetxt") as TextBox;
            TextBox txtSex = GridView1.Rows[e.RowIndex].FindControl("Sextxt") as TextBox;

            StudentEntites = new StudentEntites();

            StudentEntites.FName = txtFname.Text;
            StudentEntites.LName = txtLname.Text;
            StudentEntites.Age = Convert.ToInt32(txtAge.Text);
            StudentEntites.Sex = txtSex.Text;


            StudentBusinessLogic.UpdateStudent(id, StudentEntites);
            GridView1.EditIndex = -1;
            RefreshData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            RefreshData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            RefreshData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}