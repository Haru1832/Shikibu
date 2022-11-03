using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Command.Manager
{
    public class BackGroundManager : MonoBehaviour
    {
        [SerializeField] private Image currentBG;
        [SerializeField] private Image previousBG;

        [SerializeField] private float alphaChangeSpeed = 1f;

        public void ChangeBackGroundOfAlpha(String backGroundName)
        {
            previousBG.sprite = currentBG.sprite;

            var newBG = GetSpriteFromName(backGroundName);
            currentBG.sprite = newBG;

            var previousBgColor = previousBG.color;
            previousBgColor.a = 1;
            previousBG.color = previousBgColor;
            previousBG.DOFade(0, alphaChangeSpeed);
        }
        
        
        private Sprite GetSpriteFromName(String name)
        {
            Sprite sprite = Resources.Load<Sprite>($"BackGround/{name}");
            return sprite;
        }

    }
}