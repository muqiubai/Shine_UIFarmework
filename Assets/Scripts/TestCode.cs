using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shine.UIFramework;
using Shine.Utility;
using System.IO;

public class TestCode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/Data/");

        LogUtility.EnableSaveFile = true;

        LogUtility.InitFilePath();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
