using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CharacterImageView : MonoBehaviour
{
    private String characterName;
    public String CharacterName => characterName;

    [SerializeField] private Image image;

    [SerializeField] private float durationTime =0.5f;

    [SerializeField] private float moveTime = 1;
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

    public void AnimationActive()
    {
        var imageColor = image.color;
        imageColor.a = 0;
        image.color = imageColor;
        image.DOFade(1, durationTime);
    }

    public void SetExpression()
    {
        //TODO:キャラに合わせた表情差分の設定
    }

    public void Move(float x, float y)
    {
        Vector3 toMovePos = transform.position + new Vector3(x, y, 0);
        image.transform.DOMove(toMovePos, moveTime);
    }
}
