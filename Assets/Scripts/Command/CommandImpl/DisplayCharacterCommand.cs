using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacterCommand : ICommand
{
    private Image image;

    private List<Sprite> spriteList;

    private Transform rootObject;

    private CharacterImageView characterImagePrefab;

    private UIObjectManager _UIObjectManager;
    
    public override void Setup(UIObjectManager objectManager)
    {
        _UIObjectManager = objectManager;
        rootObject = objectManager.CharacterRootObject;
        characterImagePrefab = Resources.Load<CharacterImageView>("Prefab/CharacterImage");
    }


    public void Display(String name,float x,float y)
    {
        CharacterImageView prefab = GameObject.Instantiate(characterImagePrefab, rootObject);
        prefab.SetSprite(GetSpriteFromName(name));
        prefab.SetTransform(new Vector2(x,y));
        
        _UIObjectManager.AddCharacter(prefab);
    }


    private Sprite GetSpriteFromName(String name)
    {
        Sprite sprite = Resources.Load<Sprite>($"Character/{name}");
        return sprite;
    }
}
