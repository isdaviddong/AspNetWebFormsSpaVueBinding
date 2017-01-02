using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using isRock.Framework.PageMethods;

namespace WebApplication16
{
    public class StudentInfo
    {
        public string StudentName { get; set; }
        public float Height{ get; set; }
        public float Weight { get; set; }
        public float BMIValue { get; set; }
        public string Memo { get; set; }
    }

    public partial class _default : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<List<StudentInfo>> GetData()
        {
            //準備假資料
            List<StudentInfo> returnData = new List<WebApplication16.StudentInfo>();
            returnData.Add(new WebApplication16.StudentInfo { StudentName = "王曉明", Height = 170, Weight = 72 });
            returnData.Add(new WebApplication16.StudentInfo { StudentName = "張曉春", Height = 180, Weight = 75 });
            returnData.Add(new WebApplication16.StudentInfo { StudentName = "田豐盛", Height = 175, Weight = 60 });
            returnData.Add(new WebApplication16.StudentInfo { StudentName = "楊明山", Height = 165, Weight = 90 });
            returnData.Add(new WebApplication16.StudentInfo { StudentName = "令狐衝", Height = 172, Weight = 80 });
            //計算BMI
            foreach (var item in returnData)
            {
                var height = item.Height / 100;
                item.BMIValue = item.Weight / (height * height);
                if (item.BMIValue > 30)
                    item.Memo = "過重!";
                if (item.BMIValue < 20)
                    item.Memo = "太瘦!";
            }

            //回傳
            return new PageMethodDefaultResult<List<StudentInfo>>()
            { isSuccess = true, Data = returnData };
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}