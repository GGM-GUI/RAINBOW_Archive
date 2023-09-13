using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MonsterState
{
    Idle,
    Move,
    GetAttack,
    Explode
}

public enum MonsterColor
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple
}

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    private MonsterColor _color;

    private int attackCount = 0; 

    public bool isDie = false;

    [SerializeField]
    private GameObject itemPrefab;

    int cnt = 0;
    public float damage = 3;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("MonsterManager");
        }

        Instance = this;
    }

    private void Update()
    {
        if (_color == MonsterColor.Red)
            RedMap();
        if (_color == MonsterColor.Orange)
            OrangeMap();
        if (_color == MonsterColor.Yellow)
            YellowMap();
        if (_color == MonsterColor.Green)
            GreenMap();
        if (_color == MonsterColor.Blue)
            BlueMap(); 
        if (_color == MonsterColor.Purple)
            PurpleMap();
    }

    public void RedMap()
    {
        attackCount++;
        if (attackCount <= 3)
        {
            damage += damage * 0.03f;
        }
    }

    public void OrangeMap()
    {

    }

    public void YellowMap()
    {

    }

    public void GreenMap()
    {

    }

    public void BlueMap()
    {

    }

    public void PurpleMap()
    {

    }

    private void Fallingitems()
    {
        Vector3 itemPosition = transform.position;

        GameObject itemObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity);

        itemObject.transform.DOMoveY(-5f, 1f).SetEase(Ease.InOutQuad);
    }

    public void Die()
    {
        cnt++;
        if (isDie == true && cnt <= 5)
        {
            Fallingitems();
        }
    }
}
