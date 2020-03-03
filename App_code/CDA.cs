using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Web;
/// <summary>
/// Summary description for CDA
/// </summary>
public class CDA
{
    Hashtable connTable = new Hashtable();
    SqlConnection myConnection = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;

    HttpRequest Request = HttpContext.Current.Request;

    public CDA()
    {
        connTable.Add("BDTUBE", "Data Source=192.168.10.21;Initial Catalog=Partner_Basket;User ID=Portaluser;Password=VuPortal@2116;");
        connTable.Add("WAPDB", "Data Source=192.168.10.21;Initial Catalog=WapPortal_CMS;User ID=sa;Password=theviggo#11;");
        connTable.Add("WAPDB2", "Data Source=192.168.14.16;Initial Catalog=WapPortal_CMS;User ID=sa;Password=VU@231&#20;");
        connTable.Add("MYCHOICE", "Data Source=192.168.10.17;Initial Catalog=ShaboxWap;User ID=Portaluser;Password=VuPortal@1716;");
        connTable.Add("SMS", "Data Source=192.168.10.17;Initial Catalog=GP_URL;User ID=Portaluser;Password=VuPortal@1716;");
        connTable.Add("GP_CGW", "Data Source=192.168.10.19;Initial Catalog=GP_CGW;User ID=Portaluser;Password=VuPortal@1916;");
        connTable.Add("CityCell", "Data Source=192.168.10.17;Initial Catalog=CityCell;User ID=Portaluser;Password=VuPortal@1716;");
        connTable.Add("SBDB", "Data Source=192.168.10.21;Initial Catalog=ShaboxBuddy;User ID=Portaluser;Password=VuPortal@2116;");
        connTable.Add("BUDDY", "Data Source=192.168.10.21;Initial Catalog=ShaboxBuddy;User ID=Portaluser;Password=VuPortal@2116;");
        connTable.Add("ROBI", "Data Source=192.168.10.5;Initial Catalog=ROBI_SDP_Archive;User ID=sa;Password=VU@231&#20;");
        connTable.Add("Aurko", "Data Source=192.168.14.16;Initial Catalog=DPDP;User ID=sa;Password=VU@231&#20;");
        connTable.Add("OA", "Data Source=192.168.14.16;Initial Catalog=OnlineAd;User ID=sa;Password=VU@231&#20;");
        connTable.Add("DPDP", "Data Source=192.168.14.16;Initial Catalog=DPDP;User ID=sa;Password=VU@231&#20");
        connTable.Add("WapPortal", "Data Source=192.168.14.21;Initial Catalog=WapPortal;User ID=sa;Password=S@lDb#20&^;");

    }
    public string RawConnectionStr()
    {
        //Use for Where HashTable Connection is not used => Audio.aspx,MISmstr.aspx
        const string ConStr = "Data Source=192.168.10.21;Initial Catalog=Partner_API;User ID=Portaluser;Password=VuPortal@2116;";
        return ConStr;
    }

    public SqlDataReader getList(string query, string dbName)
    {
        myConnection = new SqlConnection(connTable[dbName].ToString());
        SqlCommand cmd = new SqlCommand(query, myConnection);
        SqlDataReader dr;
        myConnection.Open();
        dr = cmd.ExecuteReader();
        cmd = null;
        return dr;
        
    }

    public string ExecuteNonQuery(string query, string dbName)
    {
        string rValue;
        myConnection = new SqlConnection(connTable[dbName].ToString());
        try
        {
            cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            rValue = cmd.ExecuteNonQuery().ToString();
            if (rValue != "-1")
                return rValue;

            //return "OK";
            else throw new Exception();
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        finally
        {
            myConnection.Close();
            cmd = null;
            myConnection = null;
            query = null;
        }
    }

    public object getSingleValue(string query, string dbName)
    {
        //setting = ConfigurationManager.ConnectionStrings[dbName];
        myConnection = new SqlConnection(connTable[dbName].ToString());

        try
        {
            cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            object retValue = cmd.ExecuteScalar();
            return retValue;
        }
        catch (Exception ex)
        {
            return (object)ex.Message.ToString();
        }
        finally
        {
            myConnection.Close();
            cmd = null;
            myConnection = null;
            query = null;
            dbName = null;
        }
    }

    public DataSet GetDataSet(string query, string dbName)
    {
        myConnection = new SqlConnection(connTable[dbName].ToString());

        ds = new DataSet();

        try
        {
            cmd = new SqlCommand(query, myConnection);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
                return ds;
            else
                return null;
        }
        catch //(Exception ex)
        {
            return null;
        }
        finally
        {
            adapter = null;
            cmd = null;
            myConnection = null;
            query = null;
        }
    }   
    
}
