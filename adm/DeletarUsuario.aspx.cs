using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADM_DeletarUsuario : System.Web.UI.Page
{
    MembershipUserCollection users;
    protected void Page_Load(object sender, EventArgs e)
    {
        users = Membership.GetAllUsers();

        if (!this.IsPostBack)
        {
            // Bind users to ListBox.
            BindUsers();

            Msg.Text = "";

            if (!IsPostBack)
            {
                Msg.Text = "Por favor, selecione um usuário.";
            }
        }

        // If a user is selected, show the properties for the selected user.

        if (UsersListBox.SelectedItem != null)
        {
            MembershipUser u = users[UsersListBox.SelectedItem.Value];

            //EmailLabel.Text = "teste";
            IsOnlineLabel.Text = u.IsOnline.ToString();
            LastLoginDateLabel.Text = u.LastLoginDate.ToString();
            CreationDateLabel.Text = u.CreationDate.ToString();
            LastActivityDateLabel.Text = u.LastActivityDate.ToString();
        }
    }

    protected void Selected_IndexChanged(object sender, EventArgs args)
    {
        Msg.Text = "Excluir o usuário " + UsersListBox.SelectedItem.Value.ToUpper() + "?";
    }

    protected void BindUsers()
    {
        UsersListBox.DataSource = users;
        UsersListBox.DataBind();
    }

    public void YesButton_OnClick(object sender, EventArgs args)
    {
        if (UsersListBox.SelectedIndex != -1)
        {
            string user = UsersListBox.SelectedItem.Value;
            Membership.DeleteUser(user);
            Msg.Text = "Usuário " + user + " excluido.";
            BindUsers();

            string answer = "Excluido " + user + "!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('" + answer + "'); window.location.href='DeletarUsuario.aspx';", true);

        }
        else
        {
            Msg.Text = "Selecione um usuário";
        }
    }
}