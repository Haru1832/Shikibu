using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LuaFunctionGenerator : MonoBehaviour
{
    private string path = "test.txt";

    private string[] appends = new string[]
    {
        "aaaaaaaaaaaaa"
    };
    
    public void GenerateFunction()
    {
        WriteString();
        Debug.Log("Generate");
    }
    public static void WriteString()
    {
        Debug.Log(Application.persistentDataPath);
        
        FileInfo fi = new FileInfo("/Assets/Resources/Scenario/CustomLib.lua.txt");
        
        //string path = Application.persistentDataPath + "/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = fi.AppendText();
        writer.WriteLine("TestTestTest");
        writer.Close();
        //StreamReader reader = new StreamReader(path);
        //Print the text from the file
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
    }
}
