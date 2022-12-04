using UnityEngine;
using XLua;

namespace Main
{
    public class MainPresenter
    {
        private string fileName = "Scenario/";
        private static MainView _view;
        public void Initialize(MainView mainView)
        {
            _view = mainView;
            var luaEnv = new LuaEnv();
            var libText = GetScenario("lib"); //libの実行
            luaEnv.DoString(libText);
            var scenario = GetScenario("test"); // メインシナリオの実行
            luaEnv.DoString(scenario);
        }
        private string GetScenario(string path)
        {
            string pathImpl = fileName + path + ".lua";
            return Resources.Load<TextAsset>(pathImpl).text;
        }


        public static void ShowText(string text)
        {
            //_view.SetText(text);
            Debug.Log(text);
        }
    }
}