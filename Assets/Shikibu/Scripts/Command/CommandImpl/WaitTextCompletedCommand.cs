using System.Collections;
using Command.Components;
using Cysharp.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

namespace Command.CommandImpl
{
    public class WaitTextCompletedCommand : BaseShikibuCommand
    {
        
        private TweenManager _tweenManager;
        private bool isWait;
        private Button button;
        public override void Setup(UIObjectManager objectManager)
        {
            button = objectManager.ClickButton;
            _tweenManager = objectManager.GetTweenManager();
        }

        public IEnumerator WaitTextCompleted()
        {
            
            var isOk = false;
        
            button.onClick.AddListener(() => isOk = true);

            _tweenManager.isActive = true;
            yield return new WaitUntil(() => isOk);
            
            
            if (_tweenManager.isActive)
            {
                _tweenManager.DisposeTextTween();
                isOk = false;
                yield return new WaitUntil(() => isOk);
            }
            else
            {
                
            }

            // WaitClick().Forget();
            // yield return new WaitUntil(() => !_tweenManager.isActive || isWait);
            // if (_tweenManager.isActive )
            // {
            //     _tweenManager.DisposeTextTween();
            //     isOk = false;
            //     yield return new WaitUntil(() => isOk);
            // }
        }

        // public async UniTaskVoid WaitClick()
        // {
        //     WaitClickedCommand clickedCommand = new WaitClickedCommand();
        //
        //     isWait = true;
        //     await clickedCommand.Wait().ToUniTask();
        //     isWait = false;
        // }
        //
        //
        // public IEnumerator Wait()
        // {
        //
        // }
    }
}