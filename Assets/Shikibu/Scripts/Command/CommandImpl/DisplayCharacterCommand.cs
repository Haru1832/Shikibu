using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class DisplayCharacterCommand : BaseShikibuCommand
{
    private Image image;

    private List<Sprite> spriteList;

    private Transform rootObject;

    private CharacterImageView characterImagePrefab;

    private UIObjectManager _UIObjectManager;

    private MonoBehaviour _behaviour;

    private List<CharacterImageView> _characterImageViewList;

    public override void Setup(UIObjectManager objectManager)
    {
        _characterImageViewList = objectManager.CharacterImageViewList;
        _behaviour = objectManager;
        _UIObjectManager = objectManager;
        rootObject = objectManager.CharacterRootObject;
        characterImagePrefab = Resources.Load<CharacterImageView>("Prefab/CharacterImage");
    }


    public void Display(String name,float x,float y)
    {
        CharacterImageView prefab = GameObject.Instantiate(characterImagePrefab, rootObject);
        prefab.SetSprite(GetSpriteFromName(name));
        prefab.SetName(name);
        prefab.SetTransform(new Vector2(x,y));
        prefab.AnimationActive();
        
        _UIObjectManager.AddCharacter(prefab);
    }
    
    public void DeleteCharacterImage(String characterName)
    {
        _UIObjectManager.DeleteCharacterImage(characterName);
    }


    private Sprite GetSpriteFromName(String name)
    {
        Sprite sprite = Resources.Load<Sprite>($"Character/{name}");
        return sprite;
    }
}
