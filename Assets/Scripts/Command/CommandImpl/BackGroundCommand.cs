using System;
using Command.Manager;

namespace Command.CommandImpl
{
    public class BackGroundCommand : ICommand
    {
        private BackGroundManager _backGroundManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _backGroundManager = objectManager.BackGroundManager;
        }

        public void ChangeBackGroundAlpha(String backGroundName)
        {
            _backGroundManager.ChangeBackGroundOfAlpha(backGroundName);
        }
    }
}