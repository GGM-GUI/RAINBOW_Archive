using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BossHPManager : MonoBehaviour
{
    public Image hpbar;//빨간 평소 hp
    public Image bgHpbar;//맞았을 때 hp
    public GameObject dieParticle;//죽을 때 파티클
    [SerializeField] float minusTime = 0.6f;//맞았을 때 hp가 몆초동안 깎일지
    [SerializeField] string bossTag = "Boss";//보스이름
    [SerializeField] float damage = 0.1f;//fillamount얼마나 깎을지
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
