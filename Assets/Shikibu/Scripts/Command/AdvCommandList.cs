using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Command
{
    public class AdvCommandList
    {
        private List<ICommand> _commandList;

        public AdvCommandList(UIObjectManager objectManager)
        {
            _commandList = new List<ICommand>();
            Init();
            
            _commandList.ForEach(x=> x.Setup(objectManager));
        }


        void Init()
        {
            _commandList.Clear();
            
            var list = System.Reflection.Assembly.GetAssembly(typeof(ICommand))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(ICommand)) && !x.IsAbstract)
                .ToArray();
            
            foreach (var type in list)
            {
                var command = System.Activator.CreateInstance(type) as ICommand;
                _commandList.Add(command);
            }
        }


        public ICommand GetCommandOfType<T>()
        {
            return _commandList.Find(x => x.GetType() == typeof(T) );
        }
    }
}
