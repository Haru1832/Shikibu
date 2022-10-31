using DG.Tweening;

namespace Command.Components
{
    public class TweenManager
    {
        private Tween _currentTextTween;
        
        public bool isActive { get; set; }
        
        public void RegisterTextTween(Tween tween)
        {
            _currentTextTween = tween;
            isActive = true;
        }

        public void DisposeTextTween()
        {
            if(_currentTextTween == null) return;
            _currentTextTween?.Complete();
            _currentTextTween = null;
            isActive = false;
        }
    }
}