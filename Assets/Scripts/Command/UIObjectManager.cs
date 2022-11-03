using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command;
using Command.Components;
using Command.Manager;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectManager : MonoBehaviour
{
    [SerializeField] private Text mainText;
    public Text MainText => mainText;

    [SerializeField] private Text nameText;
    public Text NameText => nameText;
    
    [SerializeField] private Button clickButton;
    public Button ClickButton => clickButton;

    [SerializeField] private Transform characterRootObject;
    public Transform CharacterRootObject => characterRootObject;
    
    [SerializeField] private Transform itemRootObject;
    public Transform ItemRootObject => itemRootObject;


    [SerializeField] private BackGroundManager _backGroundManager;

    public BackGroundManager BackGroundManager => _backGroundManager;


    private List<CharacterImageView> _characterImageList = new List<CharacterImageView>();

    public List<CharacterImageView> CharacterImageViewList => _characterImageList;
    
    private List<ItemImageView> _itemImageList = new List<ItemImageView>();

    public List<ItemImageView> ItemImageViewList => _itemImageList;
    

    private TweenManager _tweenManager;

    public void AddCharacter(CharacterImageView _characterImage)
    {
        _characterImageList.Add(_characterImage);
    }

    public void AddItem(ItemImageView _itemImage)
    {
        _itemImageList.Add(_itemImage);
    }
    public void DeleteItemImage(String itemName)
    {
        var itemImageView = _itemImageList.FirstOrDefault(x=>x.ItemName == itemName);

        if (itemImageView != null)
        {
            Destroy(itemImageView.gameObject);
            _itemImageList.Remove(itemImageView);
        }
    }
    
    public void DeleteCharacterImage(String characterName)
    {
        var itemImageView = _characterImageList.FirstOrDefault(x=>x.CharacterName == characterName);

        if (itemImageView != null)
        { 
            Destroy(itemImageView.gameObject);
            _characterImageList.Remove(itemImageView);
        }
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
