using System;
using System.Collections.Generic;
using System.Linq;

namespace Command.CommandImpl
{
    public class MoveCommand : BaseShikibuCommand
    {
        private List<CharacterImageView> _characterImageViewList;
        public override void Setup(UIObjectManager objectManager)
        {
            _characterImageViewList = objectManager.CharacterImageViewList;
        }

        [ShikibuMethod]
        public void Move(String characterName, float x, float y)
        {
            var characterImageView = _characterImageViewList.FirstOrDefault(x=>x.CharacterName == characterName);
            if (characterImageView != null) characterImageView.Move(x, y);
        }
    }
}