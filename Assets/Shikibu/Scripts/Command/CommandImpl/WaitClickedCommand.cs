using System.Collections;
using System.Collections.Generic;
using Command;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WaitClickedCommand : BaseShikibuCommand
{ 
    private Button button;

    public override void Setup(UIObjectManager objectManager)
    {
        button = objectManager.ClickButton;
    }

    public IEnumerator Wait()
    {
        var isOk = false;
        
        button.onClick.AddListener(() => isOk = true);
        
        yield return new WaitUntil(() => isOk);

    }
}
