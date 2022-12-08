using System;
using Command.Manager;

namespace Command.CommandImpl
{
    public class BackGroundCommand : BaseShikibuCommand
    {
        private BackGroundManager _backGroundManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _backGroundManager = objectManager.BackGroundManager;
        }

        [ShikibuMethod]
        public void ChangeBackGroundAlpha(String backGroundName)
        {
            _backGroundManager.ChangeBackGroundOfAlpha(backGroundName);
        }
    }
}