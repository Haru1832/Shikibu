namespace Command.CommandImpl
{
    public class StartCommand : ICommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        public void Start()
        {
            _uiObjectManager.ResetCharacterImageList();
        }
    }
}