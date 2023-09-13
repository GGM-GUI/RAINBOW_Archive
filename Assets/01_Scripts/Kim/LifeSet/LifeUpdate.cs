using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LifeUpdate : MonoBehaviour
{
    static public int dieCount = 0;
    [SerializeField] private float attack; // 플레이어 공격을 얼마나 먹게 할지

    [SerializeField] private GameObject mainBossExitDoor;
    [SerializeField] private GameObject mainBossDoor = null;
    [SerializeField] private GameObject medlleBossDoor = null;
    [SerializeField] private GameObject Life; // 뒷 배경 LifeBar
    [SerializeField] private Image lifeFile; // 빨간색 LifeBar
    [SerializeField] private Image lifeAttack; // 흰색 LifeBar
    [SerializeField] float minusTime = 0.6f;//맞았을 때 hp가 몆초동안 깎일지

    static public bool isDie = false; // 죽었는지 확인하는 bool => 죽었는지 체크해야하는 스크립트에 가져가서 사용하기
    private PaletteUI palette;
    private PlayerHPUI palette2;
    LifeBarMovement lifeBarMovement;
    [Header("내가 추가했다-강윤구")]
    public BossNormalMove bnm;//내가 추가함 - ㄱㅇㄱ
    public GameObject dieParticle;//죽을 때 파티클
    private void Start()
    {
        lifeBarMovement = FindObjectOfType<LifeBarMovement>();
        palette = FindObjectOfType<PaletteUI>();
        palette2 = FindObjectOfType<PlayerHPUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("공격 성공");
            lifeFile.fillAmount -= attack;
            lifeAttack.DOFillAmount(lifeFile.fillAmount, minusTime);
            if (collision.gameObject.name != "GreenBoss")
            {
                if (lifeFile.fillAmount <= 0 && isDie == false) // 죽었을 때
                {
                    dieCount++;
                    Debug.Log(dieCount);

                    isDie = true;
                    lifeBarMovement.LifeUpMove();

                    if (dieCount == 2)
                    {
                        mainBossDoor.SetActive(true);
                        medlleBossDoor.SetActive(true);
                    }
                    else if (dieCount == 3)
                    {
                        mainBossExitDoor.SetActive(true);
                    }
                }
            }
            else
            {
                if (lifeFile.fillAmount <= 0)
                {
                    lifeBarMovement.LifeUpMove();
                    BossDie(collision.gameObject);
                }
            }
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
            palette.CollisionMarble(AgentAttackState.GREEN);
            palette2.CollisionMarble(AgentAttackState.GREEN);
            Destroy(boss);
        }
    }

    //IEnumerator LifePull()
    //{
    //    Debug.Log("생명 리셋");
    //    yield return new WaitForSeconds(0.5f);
    //    lifeFile.fillAmount = 1;
    //    lifeAttack.fillAmount = 1;
    //}
}
