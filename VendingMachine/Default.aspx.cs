using System;
using System.Data;
using System.Web.UI.WebControls;

namespace VendingMachine
{
    public partial class Default : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter data;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {   //Calls Display function
            DisplayItems();

        }
         
        //Declare Our Total Variable
        public static double Total;
        private void DisplayItems()
        {

            try
            {
                //Initialize a new instance of Connection string
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

                //Open  DB connection
                conn.Open();

            }

            catch (MySql.Data.MySqlClient.MySqlException ex) {

                Console.WriteLine(ex.Message);
            }

            queryStr = "";

            //Write a "Select" statement to a "Vending Machine Table"
            queryStr = "SELECT * FROM vendingmachinedb.vmachinetable";

            //Initialize a new instance of  DB Command string
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            //Execute MySQL Statement to fetch everything in VMachine DB 
            cmd.ExecuteNonQuery();

            //Initialize a new instances of "DataTable" and "DataAdapter" classes
            //Read and Add raws and columns from the BD table
            DataTable dt = new DataTable();
            data = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            data.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();

            //Close Opend Connection
            conn.Close(); 
        }


        //public void  UpdateItem(int prodId)
        //{

        //}

        //Purchase Selected Item Function:
        //Check if Total is not 0, Open the coonection once again to read product price and quantity.
        //Update the product quanity after every successful purchase
        //Give Necessary Messeges during successfull or unsuccessful purchase 


        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if(Total > 0)
            {
                try
                { 

                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

                conn.Open();

                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                queryStr = "SELECT * FROM vendingmachinedb.vmachinetable where product_code='" + txtProdCode.Text + "'";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    var price  = reader.GetString(reader.GetOrdinal("Product_price"));
                    var quantity = reader.GetString(reader.GetOrdinal("product_quantity"));
                    conn.Close();

                    if (!String.IsNullOrEmpty(quantity))
                    {
                        if(Total >= Convert.ToDouble(price))
                        {
                            double change = Total - Convert.ToDouble(price);
                            conn.Open();
                            queryStr = "Update vendingmachinedb.vmachinetable set product_quantity='"+ (Convert.ToInt32(quantity) - 1) + "' where product_code='" + txtProdCode.Text + "'";

                            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            lblMessage.Text = "Your Item Has Been Dispensed :), Your Change Is: "+ change + "";
                            lblAmount.Text = "";
                        }
                        else
                        {
                            lblMessage.Text = "Insufficient Funds :(";
                        }
                    }
                    else
                    {
                        
                        lblMessage.Text = "Opps Sorry! We Out Of Stock :(";

                    }
                }
                else
                {
                    lblMessage.Text = "Invalid Product Code";
                    txtProdCode.Text = "";
                }
                
            }
            else
            {
                lblMessage.Text = "Please Insert Coin";
                lblAmount.Text = "Inserted Amount = " + Total;
            }
        }

        // Switch Statement to carter for each posibility
        //Clear everything after each posibility

        protected void btnCoin_Click(object sender, EventArgs e)
        {
            
            switch (txtCoin.Text.ToLower().Trim())
            {
                case  "50c":
                case "50":
                    Total += 0.5;
                    lblMessage.Text = "";
                    txtCoin.Text = "";
                    break;
                case "r1":
                case "1":
                    Total += 1;
                    lblMessage.Text = "";
                    txtCoin.Text = "";
                    break;
                case "r2":
                case "2":
                    Total += 2;
                    lblMessage.Text = "";
                    txtCoin.Text = "";
                    break;
                case "r5":
                case "5":
                    Total += 5;
                    lblMessage.Text = "";
                    txtCoin.Text = "";
                    
                    break;
                default:
                    lblMessage.Text ="Opps! Incorrect Input";
                    break;
            }
            lblAmount.Text = "Inserted Amount: = " + Total;
        }

        //Refresh the page to show real time data from DB 
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            lblAmount.Text = "";
        }

        //Gives you back all your money once you decide not to buy
        protected void btnRefund_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Your Refund Amount Is: " + Total;
            Total = 0;
            lblAmount.Text = "Inserted Amount: = " + Total;
        }

      
    }

}