using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LifeBarMovement : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] private Image lifeFile; // »¡°£»ö LifeBar
    [SerializeField] private Image lifeAttack; // Èò»ö LifeBar

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void LifeDownMove()
    {
        rectTransform.DOAnchorPosY(-550, 2, false).SetEase(Ease.InOutCubic);
    }

    public void LifeUpMove()
    {
        rectTransform.DOAnchorPosY(-440, 2, false).SetEase(Ease.InOutCubic).OnComplete(()=> {
            lifeFile.fillAmount = 1;
            lifeAttack.fillAmount = 1;
        });
    }
}
