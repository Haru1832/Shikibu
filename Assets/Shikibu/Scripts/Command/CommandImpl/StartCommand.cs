﻿namespace Command.CommandImpl
{
    public class StartCommand : BaseShikibuCommand
    {
        private UIObjectManager _uiObjectManager;
        public override void Setup(UIObjectManager objectManager)
        {
            _uiObjectManager = objectManager;
        }

        [ShikibuMethod]
        public void Start()
        {
            _uiObjectManager.ResetCharacterImageList();
            _uiObjectManager.ResetItemImageList();
            
            _uiObjectManager.GetTweenManager().DisposeTextTween();
            _uiObjectManager.MainText.text = "";
            _uiObjectManager.NameText.text = "";
        }
    }
}