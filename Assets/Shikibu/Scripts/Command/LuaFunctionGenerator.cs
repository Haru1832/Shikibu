using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Command;
using UnityEngine;

public class LuaFunctionGenerator : MonoBehaviour
{
    private CommandExecutor _commandExecutor;
    
    private static string luaPath = "Assets/Shikibu/Resources/Scenario/CustomLib.lua.txt";

    private static string executorPath = "Assets/Shikibu/Scripts/Command/CommandExecutor";

    private static string tab = "    ";


    public void GenerateFunction()
    {
        WriteLuaMethod(GenerateLuaStrings());
        
        Debug.Log("Generate");
    }

    private string GetArgument(MethodInfo method)
    {
        string result = null;
        var args = method.GetParameters();
        foreach (var arg in args)
        {
            if (result != null)
            {
                result += ",";
            }
            result += arg.Name.ToString();
        }

        return result;
    }

    private List<string> GenerateLuaStrings()
    {
        FileInfo info = new FileInfo(luaPath);

        BindingFlags flag = BindingFlags.Public |BindingFlags.Static;

        MethodInfo[] methods = typeof(CommandExecutor).GetMethods(flag);

        List<string> methodNameList = new List<string>();

        using (StreamReader streamReader = info.OpenText())
        {
            var libraryCurrentStr = streamReader.ReadToEnd();
            foreach (var method in methods)
            {
                if (libraryCurrentStr.Contains(method.Name))
                {
                    continue;
                }

                string argumentName = GetArgument(method);

                string funcStr = null;
            
                if (method.ReturnType == typeof(IEnumerator))
                {
                    //入力形式
                    // function methodName(arg)
                    //     coroutine.yield(command.methodName(arg))
                    // end
                    funcStr = $"function {method.Name}({argumentName})\n" +
                              $"{tab}coroutine.yield(command.{method.Name}({argumentName}))\n" +
                              $"end\n";
                }
                else
                { 
                    //入力形式
                    // function methodName(arg)
                    //     command.methodName(arg)
                    // end
                    funcStr = $"function {method.Name}({argumentName})\n" +
                              $"{tab}command.{method.Name}({argumentName})\n" +
                              $"end\n";
                }
                methodNameList.Add(funcStr);
            }
        }

        return methodNameList;
    }
    
    public static void WriteLuaMethod(List<string> writeStr)
    {
        Debug.Log(Application.persistentDataPath);
        
        FileInfo fi = new FileInfo(luaPath);

        using ( StreamWriter writer = fi.AppendText())
        {
            foreach (var str in writeStr)
            {
                writer.WriteLine(str);
            }
        }

    }


    public static void WriteExecutorMethod(List<string> writeStr)
    {
        FileInfo fi = new FileInfo(executorPath);

        using (StreamReader reader = fi.OpenText())
        {
            
        }
        


        using (StreamReader reader = fi.OpenText())
        using ( StreamWriter writer = fi.AppendText())
        {
            foreach (var str in writeStr)
            {
                writer.WriteLine(str);
            }
        }
        
    }
}
