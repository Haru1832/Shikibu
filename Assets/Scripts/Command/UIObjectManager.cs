using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command;
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
}
