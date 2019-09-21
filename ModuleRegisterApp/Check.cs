using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Windows.Forms;
//using System.Web;
using System.Net;
using System.IO;


namespace ModuleRegisterApp
{
	class Check
	{
		public string IsContinue(string barcode)
		{
			//POST参数param		OK:GH984738B6YJDXVAA
			string POSTparam = "serial_cd="+barcode.Substring(0, 17).ToUpper()+ "&";			

			// paramをASCII文字列にエンコードする
			byte[] data = Encoding.ASCII.GetBytes(POSTparam);

			ServicePointManager.Expect100Continue = false; // HTTPエラー(417)対応
														   // リクエスト作成
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://172.27.32.30/pqm_aoi_api/check_module.php");
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			// ポストデータをリクエストに書き込む
			using (Stream reqStream = request.GetRequestStream())
				reqStream.Write(data, 0, data.Length);

			// レスポンスの取得
			WebResponse response = request.GetResponse();

			// 結果の読み込み
			string htmlString = "";
			using (Stream resStream = response.GetResponseStream())
			using (var reader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8")))
				htmlString = reader.ReadToEnd();

			// 結果の出力
			//OK:			{"pqm_aoi_check":"last_process=OK2SHIP:OK"}
			//NG:			{"pqm_aoi_check":"last_process=N\/A:SKIP"}
			//POST参数错误:	{}
			if (htmlString == "{\"pqm_aoi_check\":\"last_process=OK2SHIP:OK\"}")
			{
				string tempString = htmlString.Remove(0, 31).Replace("\"}", "");
				return tempString;
			}
			else if (htmlString == "{\"pqm_aoi_check\":\"last_process=N\\/A:SKIP\"}")
			{
				string tempString = htmlString.Remove(0, 31).Replace("\"}", "");
				return tempString;
			}
			else
			{
				//异常情况
				return "false";
			}
		}
	}
}