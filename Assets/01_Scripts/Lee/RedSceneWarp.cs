using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RedSceneWarp : InteractionAble
{
    [SerializeField] private int count = 0;
    private PaletteUI palette;
    private PlayerHPUI palette2;
    private void Start()
    {
        palette = FindObjectOfType<PaletteUI>();
        palette2 = FindObjectOfType<PlayerHPUI>();
        //Palette = GameObject.Find("Palette").GetComponent<PaletteUI>();
    }
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        InteractionEnd(() =>
        {
            if (count == 1)
            {
                SceneManager.LoadScene(2);
            }
            else if(count == 1)
            {
                SceneManager.LoadScene(2);
                palette.CollisionMarble(AgentAttackState.RED);
                palette2.CollisionMarble(AgentAttackState.RED);
                palette.CollisionMarble(AgentAttackState.YEOLLOW);
                palette2.CollisionMarble(AgentAttackState.YEOLLOW);
                palette.CollisionMarble(AgentAttackState.GREEN);
                palette2.CollisionMarble(AgentAttackState.GREEN);
                palette.CollisionMarble(AgentAttackState.BLUE);
                palette2.CollisionMarble(AgentAttackState.BLUE);
                palette.CollisionMarble(AgentAttackState.PURPLE);
                palette2.CollisionMarble(AgentAttackState.PURPLE);

            }
        });
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }
}
