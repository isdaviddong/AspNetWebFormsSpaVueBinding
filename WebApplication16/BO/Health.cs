using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using isRock.Framework.WebAPI;

namespace WebApplication16.BO
{
    public class StudentInfo
    {
        public string StudentName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMIValue { get; set; }
        public string Memo { get; set; }
    }

        public class Health
    {
        public ExecuteCommandDefaultResult<List<StudentInfo>> GetData()
        {
            //準備假資料
            List<StudentInfo> returnData = new List<StudentInfo>();
            returnData.Add(new StudentInfo { StudentName = "王曉明", Height = 170, Weight = 72 });
            returnData.Add(new StudentInfo { StudentName = "張曉春", Height = 180, Weight = 75 });
            returnData.Add(new StudentInfo { StudentName = "田豐盛", Height = 175, Weight = 60 });
            returnData.Add(new StudentInfo { StudentName = "楊明山", Height = 165, Weight = 90 });
            returnData.Add(new StudentInfo { StudentName = "令狐衝", Height = 172, Weight = 80 });
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
            return new ExecuteCommandDefaultResult<List<StudentInfo>>()
            {
                isSuccess = true,
                Data = returnData
            };
        }
    }
}