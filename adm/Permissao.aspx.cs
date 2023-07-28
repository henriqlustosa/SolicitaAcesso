using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADM_Permissao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {

            DropDownList1.DataSource = Membership.GetAllUsers();
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Selecione o Usuário");
            CheckBoxList1.DataSource = Roles.GetAllRoles();
            CheckBoxList1.DataBind();
        }
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCad_Click(object sender, EventArgs e)
    {
        if (!DropDownList1.SelectedIndex.Equals(0))
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    if (!Roles.IsUserInRole(DropDownList1.SelectedItem.Value, CheckBoxList1.Items[i].Value))
                        Roles.AddUserToRole(DropDownList1.SelectedItem.Value, CheckBoxList1.Items[i].Value);
                }
                else
                {
                    if (Roles.IsUserInRole(DropDownList1.SelectedItem.Value, CheckBoxList1.Items[i].Value))
                        Roles.RemoveUserFromRole(DropDownList1.SelectedItem.Value, CheckBoxList1.Items[i].Value);
                }

            }
        }

        string answer = "Permissão Gravada!";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('" + answer + "'); window.location.href='../usuario/PacienteRH.aspx';", true);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!DropDownList1.SelectedIndex.Equals(0))
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (Roles.IsUserInRole(DropDownList1.SelectedItem.Value, CheckBoxList1.Items[i].Value))
                {
                    CheckBoxList1.Items[i].Selected = true;
                }
                else
                {
                    CheckBoxList1.Items[i].Selected = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {

                CheckBoxList1.Items[i].Selected = false;

            }
        }
    }
}