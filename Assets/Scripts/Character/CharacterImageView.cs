using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CharacterImageView : MonoBehaviour
{
    private String characterName;

    [SerializeField] private Image image;

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetTransform(Vector2 vector2)
    {
        image.rectTransform.anchoredPosition = vector2;
    }
    
    public void SetName(String name)
    {
        characterName = name;
    }

    public void SetExpression()
    {
        //TODO:キャラに合わせた表情差分の設定
    }
}
