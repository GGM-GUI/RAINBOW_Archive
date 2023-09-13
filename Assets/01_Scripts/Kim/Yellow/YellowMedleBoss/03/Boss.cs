using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    public Transform player;

    [SerializeField] private int avoidDistance = 5;
    [SerializeField] private float bossHP = 5;
    [SerializeField] private GameObject YMB2;

    public bool isFlipped = false;
    private bool isBossSpawn = false;

    LifeBarMovement lifeBarMovement;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lifeBarMovement = FindObjectOfType<LifeBarMovement>();
    }

    private void Update()
    {
        if (LifeUpdate.dieCount == 1 && LifeUpdate.isDie == true && isBossSpawn == false)
        {
            isBossSpawn = true;
            StartCoroutine(BossDie());
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flippde = transform.localScale;
        flippde.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flippde;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flippde;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    IEnumerator BossDie()
    {   
        animator.SetBool("BossDie", true);
        yield return new WaitForSeconds(0.74f);
        Instantiate(YMB2, new Vector3(-37, 98, 0), Quaternion.identity);
        lifeBarMovement.LifeDownMove();
        Destroy(gameObject, 0.75f);
        LifeUpdate.isDie = false;
    }
}
