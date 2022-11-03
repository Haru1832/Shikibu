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
    private Text _mainText;
    private Text _nameText;
    private Tween _tween;

    private TweenManager _tweenManager;
    
    private float textSpeed = 30;
    
    
    public override void Setup(UIObjectManager objectManager)
    {
        _mainText = objectManager.MainText;
        _nameText = objectManager.NameText;
        _tweenManager = objectManager.GetTweenManager();
    }
    
    public void ShowText(String _talkText, String characterName = null)
    {
        if (characterName != null)
        {
            _nameText.text = characterName;
        }
        _tweenManager.DisposeTextTween();
        _mainText.text = "";
    
        float textLength = _talkText.Length;
        
    
        _tween = _mainText.DOText(_talkText, textLength / textSpeed).SetEase(Ease.Linear).OnComplete((() => _tweenManager.DisposeTextTween()));
        _tweenManager.RegisterTextTween(_tween);
    }

}
