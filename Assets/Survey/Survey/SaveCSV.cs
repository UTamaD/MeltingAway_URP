using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;
using System;


public class SaveCSV : MonoBehaviour
{
    
    public Iwantsleep iws;
    // Start is called before the first frame update
    public class Survey
    {
 
        public long Ftime;
        public long Stime;
        public long GetBtime;
        public long GetC;
      
    }
    public class CsvWriter
    {
        public static void WriteToCsv(Survey s, string filePath)
        {
            // CSV 파일의 한 행을 만듭니다.
            string row = string.Format("{0},{1},{2}, {3}", s.Ftime, s.Stime, s.GetBtime, s.GetC);

            // 파일에 행을 씁니다.
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(row);
            }
        }
    }
    public void SaveToCsv()
    {
        // CSV 파일 경로
        string csvFilePath = "BalancingFGT.csv";
        Survey s = new Survey();

        s.Ftime = iws.Ftime/100;
        s.Stime = iws.Stime / 100;
        s.GetC = iws.GetC / 100;
        s.GetBtime = iws.GetBtime / 100;


        // CSV 파일에 데이터를 저장합니다.
        CsvWriter.WriteToCsv(s, csvFilePath);
    }
    void Start()
    {
        
    }


    //이 코드 활용하여 저장된 iws값에 있는 변수들을 csv파일로 저장하는~

    //Iwantsleep iws = GameObject.Find("CSV").GetComponent<Iwantsleep>();

    /*
            survey.no = iws.No;
            survey.age = iws.age;
            survey.gen = iws.gen;
            survey.UND = iws.UND;
            survey.SKI = iws.SKI;
            survey.Alltime = iws.Alltime;
            survey.Ftime = iws.Ftime;
            survey.Stime = iws.Stime;
            survey.GetBtime = iws.GetBtime;
            survey.GetC = iws.GetC;
            survey.S2time = iws.S2time;
            survey.S3time = iws.S3time;
            survey.S4time = iws.S4time;
            survey.S5time = iws.S5time;
    */
    //SaveToCsv(survey);

    // Update is called once per frame
    void Update()
    {
        
    }
}
