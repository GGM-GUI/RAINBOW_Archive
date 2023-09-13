using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossVisual : MonoBehaviour
{
    private PaletteUI palette;
    private PlayerHPUI palette2;

    private Transform _playerTrm;
    private GameObject Boss = null;
    float x = 0;
    float y = 0;
    public Image hpbar;
    public GameObject BossBar;
    public GameObject Open;
    public GameObject Open2;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        palette = FindObjectOfType<PaletteUI>();
        palette2 = FindObjectOfType<PlayerHPUI>();
        Boss = GameObject.Find("BossRogic").gameObject;
    }

    private void Start()
    {
        _playerTrm = AgentController.Instance.transform;
    }

    private void Update()
    {
        Rotation();
        if (hpbar.fillAmount <= 0)
        {
            palette.CollisionMarble(AgentAttackState.RED);
            palette2.CollisionMarble(AgentAttackState.RED);
            BossBar.SetActive(false);
            Open.SetActive(true);
            Open2.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void Rotation()
    {
        transform.position = new Vector3(Boss.transform.position.x, Boss.transform.position.y + 0.5f, Boss.transform.position.z);
      
        if (_playerTrm.position.x - Boss.transform.position.x < 0)
        {
            x = -1;
            y = 0;
        }
        else 
        {
            x = 1;
            y = 0;
        }
        animator.SetFloat("positionY", y);
        animator.SetFloat("positionX", x);
    }
}
