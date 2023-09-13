using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BossHPManager : MonoBehaviour
{
    public Image hpbar;//���� ��� hp
    public Image bgHpbar;//�¾��� �� hp
    public GameObject dieParticle;//���� �� ��ƼŬ
    [SerializeField] float minusTime = 0.6f;//�¾��� �� hp�� �p�ʵ��� ������
    [SerializeField] string bossTag = "Boss";//�����̸�
    [SerializeField] float damage = 0.1f;//fillamount�󸶳� ������
    GameObject temp;
    public BossNormalMove bnm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag (bossTag))
        {
            temp = collision.gameObject;
            hpbar.fillAmount -= 0.1f;
            bgHpbar.DOFillAmount(hpbar.fillAmount, minusTime).OnComplete(()=>
            {
                if(hpbar.fillAmount <= 0)
                {
                    BossDie(temp);
                }
            });
        }
    }
    private void BossDie(GameObject boss)
    {
        if (dieParticle != null)
        {
            GameObject par = Instantiate(dieParticle, boss.transform.position, Quaternion.identity);
            Destroy(par, 4);
            if (bnm.enabled == true)
            {
                bnm.StopAll();
            }
        }
        boss.SetActive(false);
    }
}
