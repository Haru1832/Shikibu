using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Command
{
    public class CommandExecutor
    {
        private static AdvCommandList _commandList;

        public static void Initialize(AdvCommandList commandList)
        {
            _commandList = commandList;
        }

        // private static Dictionary<ICommand,Action<ICommand>> commandList;
        //
        // private static CommandExecutor _commandExecutor;
        //
        // public static CommandExecutor GetInstance()
        // {
        //     if (_commandExecutor == null)
        //     {
        //         _commandExecutor = new CommandExecutor();
        //         commandList = new Dictionary<ICommand, Action<ICommand>>();
        //         Debug.Log("Singleton Instance");
        //         return _commandExecutor;
        //     }
        //
        //     return _commandExecutor;
        // }
        //
        //
        // private static Action<String> onShowText;
        //
        //
        // public void Register(Action command, ICommand T)
        // {
        //     switch (T)
        //     {
        //         case ShowTextCommand showText:
        //             onShowText = command;
        //             break;
        //         
        //         
        //         default: break;
        //     }
        // }
        //
        // private static void Execute<T>(T a)
        // {
        //     Debug.Log(a.GetType());
        //     Action<ICommand> command = commandList[a.GetType()];
        // }

        public static void ShowText(String text)
        {
            var command = (ShowTextCommand)_commandList.GetCommandOfType<ShowTextCommand>();
            
            command.ShowText(text);
        }

        public static IEnumerator Wait(int time)
        {
            var command = (WaitCommand)_commandList.GetCommandOfType<WaitCommand>();

            yield return command.Wait(time);
        }

        public static IEnumerator WaitClicked()
        {
            var command = (WaitClickedCommand)_commandList.GetCommandOfType<WaitClickedCommand>();
            
            yield return command.Wait();
        }

        public static void Display(String name, float x, float y)
        {
            var command = (DisplayCharacterCommand)_commandList.GetCommandOfType<DisplayCharacterCommand>();
            
            command.Display(name, x, y);
        }
    }
}



public static class XLuaGenConfig
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>()
    {
        typeof(System.Object),
        typeof(UnityEngine.Object),
        typeof(Vector2),
        typeof(Vector3),
        typeof(Vector4),
        typeof(Quaternion),
        typeof(Color),
        typeof(Ray),
        typeof(Bounds),
        typeof(Ray2D),
        typeof(Time),
        typeof(GameObject),
        typeof(Component),
        typeof(Behaviour),
        typeof(Transform),
        typeof(Resources),
        typeof(TextAsset),
        typeof(Keyframe),
        typeof(AnimationCurve),
        typeof(AnimationClip),
        typeof(MonoBehaviour),
        typeof(ParticleSystem),
        typeof(SkinnedMeshRenderer),
        typeof(Renderer),
        typeof(WWW),
        typeof(Mathf),
        typeof(System.Collections.Generic.List<int>),
        typeof(Action<string>),
        typeof(UnityEngine.Debug),
        typeof(WaitForSeconds),
        typeof(System.Collections.IEnumerator),
    };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>()
    {
        typeof(Action),
        typeof(Func<double, double, double>),
        typeof(Action<string>),
        typeof(Action<double>),
        typeof(UnityEngine.Events.UnityAction),
        typeof(System.Collections.IEnumerator)
    };

    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()
    {
        new List<string>() {"System.Xml.XmlNodeList", "ItemOf"},
        new List<string>() {"UnityEngine.WWW", "movie"},
#if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
        new List<string>() {"UnityEngine.Texture2D", "alphaIsTransparency"},
        new List<string>() {"UnityEngine.Security", "GetChainOfTrustValue"},
        new List<string>() {"UnityEngine.CanvasRenderer", "onRequestRebuild"},
        new List<string>() {"UnityEngine.Light", "areaSize"},
        new List<string>() {"UnityEngine.Light", "lightmapBakeType"},
        new List<string>() {"UnityEngine.WWW", "MovieTexture"},
        new List<string>() {"UnityEngine.WWW", "GetMovieTexture"},
        new List<string>() {"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
        new List<string>() {"UnityEngine.Application", "ExternalEval"},
#endif
        new List<string>() {"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
        new List<string>() {"UnityEngine.Component", "networkView"}, //4.6.2 not support
        new List<string>() {"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"UnityEngine.MonoBehaviour", "runInEditMode"},
    };
}
