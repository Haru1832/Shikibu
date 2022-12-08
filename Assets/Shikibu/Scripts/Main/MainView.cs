using System;
using System.Collections;
using UnityEngine;
using XLua;

namespace Main
{
    public class MainView : MonoBehaviour
    {
        private LuaEnv _luaenv;
        private string fileName = "Scenario/";
    
        public void StartScenario()
        {
            // LuaEnvのインスタンスを生成
            // これはグローバルなものを一つだけ生成することが推奨
            _luaenv = new LuaEnv();
            
            Coroutine InvokeStartCoroutine(IEnumerator routine) => StartCoroutine(routine);
            void InvokeStopCoroutine(Coroutine coroutine) => StopCoroutine(coroutine);
            _luaenv.Global.Set("csStartCoroutine", (Func<IEnumerator, Coroutine>)InvokeStartCoroutine);
            _luaenv.Global.Set("csStopCoroutine", (Action<Coroutine>)InvokeStopCoroutine);

            var libText = GetScenario("CustomLib"); //libの実行
            _luaenv.DoString(libText);
        
            // 文字列で定義したLuaスクリプトを実行
            _luaenv.DoString(GetScenario("test"));
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
    }
}