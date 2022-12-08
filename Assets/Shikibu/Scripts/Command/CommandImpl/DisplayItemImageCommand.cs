using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemImageCommand : BaseShikibuCommand
{
    private Image image;

    private Transform rootObject;

    private ItemImageView characterImagePrefab;

    private UIObjectManager _UIObjectManager;

    private List<ItemImageView> _itemImageViewList;

    public override void Setup(UIObjectManager objectManager)
    {
        _UIObjectManager = objectManager;
        rootObject = objectManager.ItemRootObject;
        characterImagePrefab = Resources.Load<ItemImageView>("Prefab/Image");
        _itemImageViewList = objectManager.ItemImageViewList;
    }

    [ShikibuMethod]
    public void Display(String name,float x,float y)
    {
        ItemImageView prefab = GameObject.Instantiate(characterImagePrefab, rootObject);
        prefab.SetSprite(GetSpriteFromName(name));
        prefab.SetName(name);
        prefab.SetTransform(new Vector2(x,y));
        prefab.AnimationActive();
        
        _UIObjectManager.AddItem(prefab);
    }

    [ShikibuMethod]
    public void DeleteItemImage(String itemName)
    {
       _UIObjectManager.DeleteItemImage(itemName);
    }


    private Sprite GetSpriteFromName(String name)
    {
        Sprite sprite = Resources.Load<Sprite>($"Item/{name}");
        return sprite;
    }
}
