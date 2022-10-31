namespace Command.CommandImpl
{
    public class EndCommand : ICommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        public void End()
        {
            _uiObjectManager.MainText.text = "";
            
        }
    }
}