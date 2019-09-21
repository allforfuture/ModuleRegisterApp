using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Windows.Forms;
//using System.Web;
using System.Net;
using System.IO;
using System.Configuration;

namespace ModuleRegisterApp
{
    class Check
    {
        public static int minLength =Convert.ToInt16 (ConfigurationManager.AppSettings["minLength"].ToString());
        public static int maxLength = Convert.ToInt16(ConfigurationManager.AppSettings["maxLength"].ToString());
    }

    class CheckAPI
	{
		public string modelCategory(string barcode,string model)
		{
            //POST参数param		OK:GH984738B6YJDXVAA
            //string POSTparam = "seria.l_cd="+barcode.Substring(0, 17).ToUpper()+ "&";			
            string POSTparam = "serial_cd=" + barcode.ToUpper() + "&";
            // paramをASCII文字列にエンコードする
            byte[] data = Encoding.ASCII.GetBytes(POSTparam);

			ServicePointManager.Expect100Continue = false; // HTTPエラー(417)対応
                                                           // リクエスト作成

            string URIstr = string.Empty;
            switch (model)
            {
                case "KK04":
                    URIstr = "http://172.27.32.30/pqm_aoi_api/kk04/check_module.php";
                    break;
                case "KK06":
                    URIstr = "http://172.27.32.30/pqm_aoi_api/kk06/check_module.php";
                    break;
                case "KK07":
                    URIstr = "http://172.27.32.30/pqm_aoi_api/kk07/check_module.php";
                    break;
                case "KK08":
                    URIstr = "http://172.27.32.30/pqm_aoi_api/kk08/check_module.php";
                    break;
                case "KK09":
                    URIstr = "http://172.27.32.30/pqm_aoi_api/kk09/check_module.php";
                    break;
                    //default:
                    //    break;
            }
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://172.27.32.30/pqm_aoi_api/check_module.php");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URIstr);

            request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			// ポストデータをリクエストに書き込む
			using (Stream reqStream = request.GetRequestStream())
				reqStream.Write(data, 0, data.Length);

			// レスポンスの取得
			WebResponse response = request.GetResponse();

			// 結果の読み込み
			string APIstr = "";
			using (Stream resStream = response.GetResponseStream())
			using (var reader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8")))
				APIstr = reader.ReadToEnd();

            // 結果の出力            
            //NG:			{"pqm_aoi_check":"last_process=N\/A:SKIP"}
            //OK:			{"pqm_aoi_check":"last_process=OK2SHIP:OK"}
            //              {"pqm_aoi_check":"last_process=OK2SHIP:NG"}
            //POST参数错误:	{}
            try
            {
                int i = APIstr.LastIndexOf("=");
                int j = APIstr.LastIndexOf("\"");
                return APIstr.Substring(i + 1, j - i - 1);
            }
            catch { return "false"; }
		}
	}
}