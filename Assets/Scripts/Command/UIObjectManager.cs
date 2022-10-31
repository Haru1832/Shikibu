using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command;
using Command.Components;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectManager : MonoBehaviour
{
    [SerializeField] private Text mainText;
    public Text MainText => mainText;
    
    [SerializeField] private Button clickButton;
    public Button ClickButton => clickButton;

    [SerializeField] private Transform characterRootObject;
    public Transform CharacterRootObject => characterRootObject;


    private List<CharacterImageView> _characterImageList = new List<CharacterImageView>();

    private TweenManager _tweenManager;

    public void AddCharacter(CharacterImageView _characterImage)
    {
        _characterImageList.Add(_characterImage);
    }

    public void ResetCharacterImageList()
    {
        _characterImageList.ForEach(x =>
        {
            Destroy(x.gameObject);
        });
        _characterImageList.Clear();
    }

    public TweenManager GetTweenManager()
    {
        if (_tweenManager != null)
        {
            return _tweenManager;
        }

        _tweenManager = new TweenManager();
        return _tweenManager;

    }

    private void Update()
    {
        Debug.Log(_tweenManager.isActive);
    }
}
