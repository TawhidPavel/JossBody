using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FitnessSession : System.Web.UI.Page
{
    CDA CA = new CDA();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadZumba();
            loadYoga();
            loadEasyWorkOut();
        }

    }

    private void loadEasyWorkOut()
    {
        DataSet dsVdo = null;
        dsVdo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness 'E0AEF450-099B-495F-B056-8AED4B95F00A', 4", "WAPDB");

        repeaterEasyWorkOut.DataSource = dsVdo;
        repeaterEasyWorkOut.DataBind();
    }

    private void loadZumba()
    {
        DataSet dsVdo = null;
        dsVdo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '413623EB-E3BF-4494-8BB8-0302473A91A1', 4", "WAPDB");

        repeaterZumba.DataSource = dsVdo;
        repeaterZumba.DataBind();
    }


    private void loadYoga()
    {
        DataSet dsVdo = null;
        dsVdo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '44EAE2BC-F85F-483E-9C8E-B76D84114C00', 4", "WAPDB");

        repeaterYoga.DataSource = dsVdo;
        repeaterYoga.DataBind();
    }
}