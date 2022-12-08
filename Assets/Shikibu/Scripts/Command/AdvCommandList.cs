using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Command
{
    public class AdvCommandList
    {
        private List<BaseShikibuCommand> _commandList;

        public AdvCommandList(UIObjectManager objectManager)
        {
            _commandList = new List<BaseShikibuCommand>();
            Init();
            
            _commandList.ForEach(x=> x.Setup(objectManager));
        }


        void Init()
        {
            _commandList.Clear();
            
            var list = System.Reflection.Assembly.GetAssembly(typeof(BaseShikibuCommand))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(BaseShikibuCommand)) && !x.IsAbstract)
                .ToArray();
            
            foreach (var type in list)
            {
                var command = System.Activator.CreateInstance(type) as BaseShikibuCommand;
                _commandList.Add(command);
            }
        }


        public BaseShikibuCommand GetCommandOfType<T>()
        {
            return _commandList.Find(x => x.GetType() == typeof(T) );
        }
    }
}
