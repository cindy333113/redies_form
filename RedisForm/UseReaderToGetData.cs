using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisForm
{
    internal class UseReaderToGetData
    {
        ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings.Get("connstring"));
        Boolean HasSearchStock;
        Boolean StockHasValue = true;
        Boolean DataTableHasValue = true;
        public string GetData(string requestJson)
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestJson);
            string s_data = ConfigurationManager.AppSettings.Get("dbConnect");

            //new一個SqlConnection物件，是與資料庫連結的通道(其名為Connection)，以s_data內的連接字串連接所對應的資料庫。
            SqlConnection connection = new SqlConnection(s_data);
            SqlCommand Command;

            System.Text.StringBuilder sb = new System.Text.StringBuilder("SELECT * FROM dbo.[stord] where ");
            sb.Append("bhno=@bhno ");
            sb.Append("AND cSeq=@cSeq ");
            sb.Append("AND eType=@eType ");
            sb.Append("AND tType=@tType ");
            if (request.content.stock == "")
            {
                HasSearchStock = false;
                Command = new SqlCommand(sb.ToString(), connection);
            }
            else
            {
                HasSearchStock = true;
                sb.Append("AND stock=@stock");
                Command = new SqlCommand(sb.ToString(), connection);
                Command.Parameters.AddWithValue("@stock", request.content.stock);
            }

            Command.Parameters.AddWithValue("@bhno", request.bhNo);
            Command.Parameters.AddWithValue("@cSeq", request.cSeq);
            Command.Parameters.AddWithValue("@eType", request.content.eType);
            Command.Parameters.AddWithValue("@tType", request.content.tType);
            //與資料庫連接的通道開啟
            connection.Open();

            //new一個DataReader接取Execute所回傳的資料。
            SqlDataReader dr = Command.ExecuteReader();

            List<Response> response = new List<Response>();  
            //檢查是否有資料列
            if (dr.HasRows)
            {
                //使用Read方法把資料讀進Reader，讓Reader一筆一筆順向指向資料列，並回傳是否成功。
                while (dr.Read())
                {
                    string key = dr["mType"].ToString() + "," + (dr["stock"]).ToString().Trim();
                    ArrayList redisDataList = GetValue(key);
                    if (!(bool)redisDataList[0])
                    {
                        //查無資料
                        StockHasValue = false;
                    }
                    else
                    {
                        RedisValue josnValue = (RedisValue)redisDataList[1];
                        response.Add(new Response
                        {
                            bhNo = request.bhNo,
                            cSeq = request.cSeq,
                            content = new Response.Content()
                            {
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
                                stockName = josnValue.StockName,
                                ordKnd = dr["ordKnd"].ToString(),
                                pCond = dr["pCond"].ToString(),
                                tQty = dr["tQty"].ToString(),
                                cQty = dr["cQty"].ToString(),
                                mQty = dr["mQty"].ToString(),
                                uQty = dr["uQty"].ToString(),
                                price = dr["price"].ToString(),
                                currentprice = josnValue.Currentprice,
                                sales = dr["sales"].ToString(),
                                origSource = dr["origSource"].ToString(),
                                statusCode = dr["statusCode"].ToString(),
                                statusText = dr["statusText"].ToString().Trim(),
                                iDate = dr["iDate"].ToString().Trim(),
                                tDate = dr["tDate"].ToString().Trim(),
                                rTime = dr["rTime"].ToString().Trim(),
                            }
                        });
                    }                   
                }
            }

            //關閉與資料庫連接的通道
            connection.Close();
            if (response.Count == 0)
            {
                DataTableHasValue=false;
            }
            return JsonConvert.SerializeObject(response);
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
        public Boolean CheckSearchStockHasValue()
        {
            if (HasSearchStock & (!StockHasValue | !DataTableHasValue))
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
