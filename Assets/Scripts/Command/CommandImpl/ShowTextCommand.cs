using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using ICommand = Command.ICommand;

public class ShowTextCommand : ICommand
{
    private Text _text;
    private Tween _tween;

    private float textSpeed = 30;
    
    
    public override void Setup(UIObjectManager objectManager)
    {
        _text = objectManager.MainText;
    }
    
    public void ShowText(String _talkText)
    {
        _tween.Complete();
        _text.text = "";
    
        float textLength = _talkText.Length;
        
    
        _tween = _text.DOText(_talkText, textLength / textSpeed).SetEase(Ease.Linear);
    }

}
