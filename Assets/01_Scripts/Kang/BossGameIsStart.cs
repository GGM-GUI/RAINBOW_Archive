using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class BossGameIsStart : MonoBehaviour
{
    public BossNormalMove bossMove;
    bool isNotPlay = true;
    public CinemachineVirtualCamera cvc;
    public GameObject boss;
    public RectTransform hpbar;
    [SerializeField] private float downBarPos;
    [SerializeField] private LifeBarMovement lifeBar;
    void Update()
    {
        if (AgentController.Instance.PlayerTrm.position.x < 84.4f && AgentController.Instance.PlayerTrm.position.x > 52.3f && AgentController.Instance.PlayerTrm.position.y < -58.2 && AgentController.Instance.PlayerTrm.position.y > -91)
        {
            if(isNotPlay == true)
            {
                StartCoroutine(start());
                isNotPlay = false;
            }
        }
        else
        {
            isNotPlay = true;
        }
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(2.5f);
        cvc.Priority = 15;
        yield return new WaitForSeconds(1);
        boss.SetActive(true);
        yield return new WaitForSeconds(3);
        lifeBar.LifeDownMove();
        cvc.Priority = 5;
        bossMove.enabled = true;
    }
}
