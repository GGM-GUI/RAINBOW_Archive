using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : StateMachineBehaviour
{
    public float speed = 2.5f;

    Transform player;
    Rigidbody2D rd;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = AgentController.Instance.PlayerTrm.transform;
        //player = GameObject.FindGameObjectWithTag("player").transform;
        rd = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rd.position, target, speed * Time.fixedDeltaTime);
        rd.MovePosition(newPos);
    }
}
