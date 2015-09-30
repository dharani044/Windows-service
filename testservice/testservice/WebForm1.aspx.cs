using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testservice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=AMX-535-PC;Initial Catalog=sample;Integrated Security=True";
            SqlConnection c = new SqlConnection(cs);
            string query = @"SELECT i.enddate, CONVERT(date,O.OrderDate) AS Date, 
                           P.ProductName, I.Quantity, I.UnitPrice 
                           FROM [Order] O 
                           JOIN OrderItem I ON O.Id = I.OrderId 
                           JOIN Product P ON P.Id = I.ProductId
                           ORDER BY O.OrderNumber";
        }
    }
}