﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SemPermissao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVoltarP_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/aberto/PaginaInicial.aspx"); // Redireciona se não for admin
    }
}