using System;

namespace Command.CommandImpl
{
    public class ChangeCharacterImageCommand : ICommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        public void ChangeCharacterImage(String characterName, String changeCharacterName)
        {
            
        }
    }
}