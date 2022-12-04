using System;
using UnityEngine;
using XLua;


public class Example : MonoBehaviour
{
    //public TextAsset luaScript;
    private LuaEnv _luaenv;
    private string fileName = "Scenario/";
    
    void Start()
    {
        // LuaEnvのインスタンスを生成
        // これはグローバルなものを一つだけ生成することが推奨
        _luaenv = new LuaEnv();

        var libText = GetScenario("lib"); //libの実行
        _luaenv.DoString(libText);
        
        // 文字列で定義したLuaスクリプトを実行
        _luaenv.DoString(GetScenario("test"));
        Debug.Log("aa");
    }
    private void OnDestroy()
    {
        _luaenv.Dispose();
    }
    
    private string GetScenario(string path)
    {
        string pathImpl = fileName + path + ".lua";
        return Resources.Load<TextAsset>(pathImpl).text;
    }

    public static void ShowText(string text)
    {
        Debug.Log(text);
    }
}