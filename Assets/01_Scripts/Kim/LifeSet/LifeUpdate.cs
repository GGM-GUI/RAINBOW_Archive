using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LifeUpdate : MonoBehaviour
{
    static public int dieCount = 0;
    [SerializeField] private float attack; // �÷��̾� ������ �󸶳� �԰� ����

    [SerializeField] private GameObject mainBossExitDoor;
    [SerializeField] private GameObject mainBossDoor = null;
    [SerializeField] private GameObject medlleBossDoor = null;
    [SerializeField] private GameObject Life; // �� ��� LifeBar
    [SerializeField] private Image lifeFile; // ������ LifeBar
    [SerializeField] private Image lifeAttack; // ��� LifeBar
    [SerializeField] float minusTime = 0.6f;//�¾��� �� hp�� �p�ʵ��� ������

    static public bool isDie = false; // �׾����� Ȯ���ϴ� bool => �׾����� üũ�ؾ��ϴ� ��ũ��Ʈ�� �������� ����ϱ�
    private PaletteUI palette;
    private PlayerHPUI palette2;
    LifeBarMovement lifeBarMovement;
    [Header("���� �߰��ߴ�-������")]
    public BossNormalMove bnm;//���� �߰��� - ������
    public GameObject dieParticle;//���� �� ��ƼŬ
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
            Debug.Log("���� ����");
            lifeFile.fillAmount -= attack;
            lifeAttack.DOFillAmount(lifeFile.fillAmount, minusTime);
            if (collision.gameObject.name != "GreenBoss")
            {
                if (lifeFile.fillAmount <= 0 && isDie == false) // �׾��� ��
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
    //    Debug.Log("���� ����");
    //    yield return new WaitForSeconds(0.5f);
    //    lifeFile.fillAmount = 1;
    //    lifeAttack.fillAmount = 1;
    //}
}
