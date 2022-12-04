using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class CSVReader : MonoBehaviour {
    const string SHEET_ID = "1k4_-tV1dxcN_wUsAfxu4Tvs6CbszX8krvtva6DyJPjg";
    const string SHEET_NAME = "シート1";

    private void Start()
    {
        Debug.Log("test");
        StartCoroutine(Method(SHEET_NAME));
    }


    IEnumerator Method(string _SHEET_NAME){
        Debug.Log("test");
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/"+SHEET_ID+"/gviz/tq?tqx=out:csv&sheet="+_SHEET_NAME);
        yield return request.SendWebRequest();

        if(request.isHttpError || request.isNetworkError) {
            Debug.Log(request.error);
        }
        else{

            List<string[]> characterDataArrayList = ConvertToArrayListFrom(request.downloadHandler.text);           
            foreach(string[] characterDataArray in characterDataArrayList){
                CharacterData characterData = new CharacterData(characterDataArray);
                characterData.DebugParametaView();
            }
        }
    }

    List<string[]> ConvertToArrayListFrom(string _text){
        List<string[]> characterDataArrayList = new List<string[]>();
        StringReader reader = new StringReader(_text);
        reader.ReadLine();  // 1行目はラベルなので外す
        while (reader.Peek() != -1){
            string line = reader.ReadLine();        // 一行ずつ読み込み
            string[] elements = line.Split(',');    // 行のセルは,で区切られる
            for(int i=0; i<elements.Length; i++){
                if(elements[i] == "\"\""){
                    continue;                       // 空白は除去
                }
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            characterDataArrayList.Add(elements);
        }
        return characterDataArrayList;
    }
    
    void ViewCSV(string _text){
        StringReader reader = new StringReader(_text);
        string[] headerline = null;
        while (reader.Peek() != -1){
            string line = reader.ReadLine();        // 一行ずつ読み込み
            string[] elements = line.Split(',');    // 行のセルは,で区切られる
            for(int i=0; i<elements.Length; i++){
                if(elements[i] == "\"\""){
                    continue;                       // 空白は除去
                }
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
                Debug.Log(elements[i]);
            }
        }
    }
}