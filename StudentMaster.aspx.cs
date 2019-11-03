using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentMaster : System.Web.UI.Page
{
    clsStudentMaster obj = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = 1;
        if (!IsPostBack)
        {
            BindGridview();
        }
    }

    public void BindGridview()
    {
        obj = new clsStudentMaster();
        gvStudentMaster.DataSource = obj.SelectStudentMaster(0);
        gvStudentMaster.DataBind();

        chkSubject.DataSource = obj.SelectSubjectList();
        chkSubject.DataTextField = "Name";
        chkSubject.DataValueField = "SubjectID";
        chkSubject.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        obj = new clsStudentMaster();
        obj.StudentID = hdfID.Value == string.Empty ? 0 : Convert.ToInt32(hdfID.Value);
        obj.Name = txtName.Text.Trim();
        obj.MobileNo = txtMobileNo.Text.Trim();
        obj.EmailID = txtEmail.Text.Trim();
        obj.Address = txtAddress.Text.Trim();
        obj.DOB = calDOB.SelectedDate.Date;
        obj.RollNo = txtrollno.Text.Trim();
        obj.UserID = Convert.ToInt32(Session["UserID"]);
        if (obj.InsertUpdateStudentMaster(obj) > 0)
        {
            InsertStudentSubject(obj.StudentID);
            lblStatus.Text = "Record " + (hdfID.Value == string.Empty ? "Inserted" : "Updated") + " Successfully";
            Clear();
            BindGridview();
        }
        else
        {
            lblStatus.Text = "Opertation Failed!!!";
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        hdfID.Value = string.Empty;
        txtName.Text = string.Empty;
        txtMobileNo.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtrollno.Text = string.Empty;
        calDOB.SelectedDate = DateTime.Now.Date;
        chkSubject.ClearSelection();
        btnSubmit.Text = "Insert";
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        int StudentID = Convert.ToInt32(gvStudentMaster.DataKeys[gvr.RowIndex]["StudentID"].ToString());
        obj = new clsStudentMaster();
        DataTable dt = obj.SelectStudentMaster(StudentID);
        if (dt.Rows.Count > 0)
        {
            hdfID.Value = dt.Rows[0]["StudentID"].ToString();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtrollno.Text = dt.Rows[0]["RollNo"].ToString();
            calDOB.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SDOB"].ToString());
            btnSubmit.Text = "Update";
            chkSubject.ClearSelection();
            DataTable dt1 = obj.SelectStudentSubjectList(StudentID);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    chkSubject.Items.FindByValue(dt1.Rows[i]["SubjectID"].ToString()).Selected = true;
                }
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        int StudentID = Convert.ToInt32(gvStudentMaster.DataKeys[gvr.RowIndex]["StudentID"].ToString());
        obj = new clsStudentMaster();
        obj.StudentID = StudentID;
        obj.UserID = Convert.ToInt32(Session["UserID"]);
        if (obj.DeleteStudentMaster(obj) > 0)
        {
            lblStatus.Text = "Record Deleted Successfully";
            BindGridview();
        }
        else
        {
            lblStatus.Text = "Opertation Failed!!!";
        }
    }

    public void InsertStudentSubject(int StudentID)
    {
        DeleteStudentSubject(StudentID);
        foreach (ListItem chk in chkSubject.Items)
        {
            if (chk.Selected)
            {
                obj = new clsStudentMaster();
                obj.StudentID = StudentID;
                obj.SubjectID = Convert.ToInt32(chk.Value);
                obj.InsertStudentSubject(obj);
            }
        }
    }

    public void DeleteStudentSubject(int StudentID)
    {
        obj = new clsStudentMaster();
        obj.DeleteStudentSubject(StudentID);
    }
}