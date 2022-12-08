namespace Command.CommandImpl
{
    public class EndCommand : BaseShikibuCommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        
        [ShikibuMethod]
        public void End()
        {
            _uiObjectManager.MainText.text = "";
            _uiObjectManager.NameText.text = "";
        }
    }
}