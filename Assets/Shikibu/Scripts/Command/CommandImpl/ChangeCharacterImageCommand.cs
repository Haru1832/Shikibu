using System;

namespace Command.CommandImpl
{
    public class ChangeCharacterImageCommand : BaseShikibuCommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        [ShikibuMethod]
        public void ChangeCharacterImage(String characterName, String changeCharacterName)
        {
            
        }
    }
}