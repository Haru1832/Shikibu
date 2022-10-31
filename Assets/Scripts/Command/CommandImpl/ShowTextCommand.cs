using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using Command.Components;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using ICommand = Command.ICommand;

public class ShowTextCommand : ICommand
{
    private Text _text;
    private Tween _tween;

    private TweenManager _tweenManager;
    
    private float textSpeed = 30;
    
    
    public override void Setup(UIObjectManager objectManager)
    {
        _text = objectManager.MainText;
        _tweenManager = objectManager.GetTweenManager();
    }
    
    public void ShowText(String _talkText)
    {
        _tweenManager.DisposeTextTween();
        _text.text = "";
    
        float textLength = _talkText.Length;
        
    
        _tween = _text.DOText(_talkText, textLength / textSpeed).SetEase(Ease.Linear).OnComplete((() => _tweenManager.DisposeTextTween()));
        _tweenManager.RegisterTextTween(_tween);
    }

}
