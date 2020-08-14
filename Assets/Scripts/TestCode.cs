using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shine.UIFramework;
using Shine.Utility;
using System.IO;
using Unity.UNetWeaver;

public class TestCode : MonoBehaviour
{

    List<string> lines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lines.Add("第一条");
        lines.Add("第二条");
        lines.Add("第三条");
        lines.Add("第四条");
        lines.Add("第五条");

        LogUtility.EnableOutput = true;
        LogUtility.logs.Add("测试1");
        LogUtility.logs.Add("测试2");
        LogUtility.logs.Add("测试3");

        LogUtility.EnableSaveFile = true;
        LogUtility.InitFilePath();
        LogUtility.WriteLogToFile(lines);

        LogUtility.WriteLogToFile("第七条");
        LogUtility.WriteLogToFile("第六条");
        LogUtility.WriteLogToFile("测试信息");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        LogUtility.DisplayOnScreen();
    }
}
