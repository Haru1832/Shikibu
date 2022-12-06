using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Command;
using UnityEngine;

public class LuaFunctionGenerator : MonoBehaviour
{
    private CommandExecutor _commandExecutor;
    
    private static string luaPath = "Assets/Shikibu/Resources/Scenario/CustomLib.lua.txt";

    private static string executorPath = "Assets/Shikibu/Scripts/Command/CommandExecutor.cs";

    private static string textBasePath = "Assets/Shikibu/Scripts/Command/TextBase";
    
    private static string executorBasePath = textBasePath + "/CommandExecutorBase.txt";
    
    private static string luaBasePath = textBasePath + "/BaseCustomLib.lua.txt";
    
    private static string tmpLuaBasePath = textBasePath + "/TmpLuaCommand.lua.txt";

    private static string tmpExecutorPath = textBasePath + "/TmpCommandExecutor.cs";

    private static string tab = "    ";


    public void GenerateFunction()
    {
        WriteLuaMethod(GenerateLuaStrings());
        
        WriteExecutorMethod(GenerateExecutorStrings());
        Debug.Log("Generate");
    }

    private string GetLuaArgument(MethodInfo method)
    {
        string result = null;
        var args = method.GetParameters();
        foreach (var arg in args)
        {
            if (result != null)
            {
                result += ",";
            }
            result += arg.Name;
        }

        return result;
    }
    
    private string GetExecutorArgument(MethodInfo method)
    {
        string result = null;
        var args = method.GetParameters();
        foreach (var arg in args)
        {
            if (result != null)
            {
                result += ",";
            }

            result += $"{arg.ParameterType} {arg.Name}";
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

                string argumentName = GetLuaArgument(method);

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
    
    
    private List<string> GenerateExecutorStrings()
    {
        FileInfo baseFile = new FileInfo(executorBasePath);

        int value = CommandExecutor.EditLineNum;

        int currentline = 1;
        StringBuilder result = new StringBuilder();
        
        using (StreamReader reader = baseFile.OpenText())
        {
            string currentText;
            
            while ((currentText = reader.ReadLine()) != null)
            {
                if (currentline == value)
                {
                    var methodStrings = getMethodString();
                    StringReader stringReader = new StringReader(methodStrings);
                
                    //改行の数だけ現在の行数を足す
                    while (stringReader.ReadLine() != null)
                    {
                        currentline++;
                    }
                    result.AppendLine(methodStrings);
                }
            
                result.AppendLine(currentText);
                currentline ++;
            }
            
        }

        List<string> resultList = new List<string>();
        
        StringReader resultReader = new StringReader(result.ToString());

        string tmp = null;
        //改行の数だけ現在の行数を足す
        while ((tmp = resultReader.ReadLine()) != null)
        {
            resultList.Add(tmp);
        }

        return resultList;
        

        string getMethodString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\n");

            var list = System.Reflection.Assembly.GetAssembly(typeof(ICommand))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(ICommand)) && !x.IsAbstract)
                .ToArray();
        
            foreach (var type in list)
            {
                var commandImpl = System.Activator.CreateInstance(type) as ICommand;
                var commandMethods = commandImpl?.GetType().GetMethods();

                foreach (var method in commandMethods)
                {
                    ShikibuMethod shikibuMethod = method.GetCustomAttribute<ShikibuMethod>();

                    if (shikibuMethod != null)
                    {
                        string attribute;
                    
                        switch (shikibuMethod.Optional)
                        {
                            case ShikibuEnum.UseLuaCallCsSharp :
                                attribute = "LuaCallCSharp";
                                break;
                            case ShikibuEnum.ReflectionUse :
                                attribute = "ReflectionUse";
                                break;
                            default:
                                attribute = null;
                                break;
                        }
                        
                        
                        string methodName = shikibuMethod.Name ?? method.Name;
                        string methodType = type.ToString();

                        string funcStr = $"[{attribute}]\n" +
                                         $"public static {method.ReturnType} {methodName}({GetExecutorArgument(method)})\n" +
                                         "{\n" +
                                         $"{tab}{methodType} command = ({methodType})_commandList.GetCommandOfType<{methodType}>();\n" +
                                         $"{tab}command.{method.Name}({GetLuaArgument(method)});" +
                                         "}\n";

                        stringBuilder.Append(funcStr);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
    
    public static void WriteLuaMethod(List<string> writeStr)
    {
        Debug.Log(Application.persistentDataPath);
        
        FileInfo fi = new FileInfo(tmpExecutorPath);

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
        using (var fileStream = new FileStream(tmpExecutorPath, FileMode.Open))
        {
            fileStream.SetLength(0);
        }
        
        using ( StreamWriter writer = new StreamWriter(tmpExecutorPath, false))
        {
            foreach (var str in writeStr)
            {
                writer.WriteLine(str);
            }
        }
        
        File.Copy(tmpExecutorPath, executorPath, true);
        
    }
}
