using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisForm
{
    internal class UseAdapterToGetData
    {
        public virtual string[] _col { set; get; }
        public virtual int[] _splitRow { set; get; }
        private DataTable _dt = null;
        ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings.Get("connstring"));
        Boolean HasSearchStock ;
        Boolean StockHasValue =true;
        Boolean DataTableHasValue = true;
        public  DataTable getDataFromDB(string requestJson)
        {
            DataTable dataTable = new DataTable();
            Request request = JsonConvert.DeserializeObject<Request>(requestJson);
            System.Text.StringBuilder sb = new System.Text.StringBuilder("SELECT * FROM dbo.[stord] where ");
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("dbConnect"));
            conn.Open();
            SqlCommand command ;
            sb.Append("bhno=@bhno ");
            sb.Append("AND cSeq=@cSeq ");
            sb.Append("AND eType=@eType ");
            sb.Append("AND tType=@tType ");
            if (request.content.stock == "")
            {
                HasSearchStock = false;
                command = new SqlCommand(sb.ToString(), conn);}
            else
            {
                HasSearchStock = true;
                sb.Append("AND stock=@stock");
                command = new SqlCommand(sb.ToString(), conn);
                command.Parameters.AddWithValue("@stock", request.content.stock);
            }
            command.Parameters.AddWithValue("@bhno", request.bhNo);
            command.Parameters.AddWithValue("@cSeq", request.cSeq);
            command.Parameters.AddWithValue("@eType", request.content.eType);
            command.Parameters.AddWithValue("@tType", request.content.tType);

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            dataTable = getDataFromRedis(dataTable);
            if (dataTable.DataSet==null)
            {
                DataTableHasValue=false;
            }
            return dataTable;
        }
        public string ConvertDataTabletoString(string requestJson)
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestJson);
            DataTable dt = getDataFromDB(requestJson);
            List<Response> responses = new List<Response>();
            foreach (DataRow dr in dt.Rows)
            {
                Response res = new Response() {
                    bhNo = request.bhNo,
                    cSeq = request.cSeq,
                    content = new Response.Content() {
                        bhNo = dr["bhNo"].ToString().Trim(),
                        cSeq = dr["cSeq"].ToString().Trim(),
                        rSeq = dr["cSeq"].ToString().Trim(),
                        tSeq = dr["tSeq"].ToString().Trim(),
                        netSeq = dr["netSeq"].ToString().Trim(),
                        dSeq = dr["dSeq"].ToString().Trim(),
                        mType = dr["mType"].ToString(),
                        eType = dr["eType"].ToString(),
                        oType = dr["oType"].ToString(),
                        tType = dr["tType"].ToString(),
                        bsType = dr["bsType"].ToString(),
                        stock = dr["stock"].ToString().Trim(),
                        stockName = dr["stockName"].ToString(),
                        ordKnd = dr["ordKnd"].ToString(),
                        pCond = dr["pCond"].ToString(),
                        tQty = dr["tQty"].ToString(),
                        cQty = dr["cQty"].ToString(),
                        mQty = dr["mQty"].ToString(),
                        uQty = dr["uQty"].ToString(),
                        price = dr["price"].ToString(),
                        currentprice = dr["currentprice"].ToString(),
                        sales = dr["sales"].ToString(),
                        origSource = dr["origSource"].ToString(),
                        statusCode = dr["statusCode"].ToString(),
                        statusText = dr["statusText"].ToString().Trim(),
                        iDate = dr["iDate"].ToString().Trim(),
                        tDate = dr["tDate"].ToString().Trim(),
                        rTime = dr["rTime"].ToString().Trim(),
                    }
                };
            responses.Add(res);
            }
           return JsonConvert.SerializeObject(responses);
        }
        public DataTable getDataFromRedis(DataTable dataTable)
        {
            DataColumn newCol = new DataColumn("stockName", typeof(string));
            DataColumn newCol2 = new DataColumn("currentprice", typeof(string));
            dataTable.Columns.Add(newCol);
            dataTable.Columns.Add(newCol2);
            List<DataRow> rowsToBeDeleted = new List<DataRow>();
            foreach (DataRow row in dataTable.Rows)
            {
                string redisKey = (string)row["mType"] +","+ ((string)row["stock"]).Trim();
                ArrayList redisDataList = GetValue(redisKey);
                if (!(bool)redisDataList[0])
                {
                    //查無資料 刪除列
                    rowsToBeDeleted.Add(row);
                    StockHasValue=false;
                }
                else
                {
                    RedisValue josnValue = (RedisValue)redisDataList[1];
                    row["stockName"] = josnValue.StockName;
                    row["currentprice"] = josnValue.Currentprice;
                }
            }
            foreach (DataRow row in rowsToBeDeleted)
            {
                dataTable.Rows.Remove(row);
            }
            return dataTable;
        }
        public ArrayList GetValue(string key)
        {
            var db = conn.GetDatabase();
            var test = db.StringGet(key);
            ArrayList redisDataList = new ArrayList();
            RedisValue josnValue = new RedisValue();
            if (test.HasValue)
            {
                josnValue = JsonConvert.DeserializeObject<RedisValue>(test);
            }
            redisDataList.Add(test.HasValue);
            redisDataList.Add(josnValue);
            return redisDataList;
        }
        public DataGridView setColumOrder(DataGridView view)
        {
            string[] columOrder = { "bhNo", "cSeq", "rSeq", "tSeq", "netSeq", "dSeq", "mType", "eType", "tType", "tType", "bsType", "stock", "stockName", "ordKnd", "pCond", "tQty", "cQty", "mQty", "uQty", "price", "currentprice", "sales", "origSource", "statusCode" };
            
            for (int i = 0; i < columOrder.Length; i++)
            {
                view.Columns[columOrder[i]].DisplayIndex = i;
            }
            return view;
        }
        public Boolean CheckSearchStockHasValue()
        {
            if (HasSearchStock & (!StockHasValue| !DataTableHasValue))
            {                
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
