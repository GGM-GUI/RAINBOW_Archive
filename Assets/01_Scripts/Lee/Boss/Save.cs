using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private PaletteUI palette;
    private PlayerHPUI palette2;
    // Start is called before the first frame update
    void Start()
    {
        palette = FindObjectOfType<PaletteUI>();
        palette2 = FindObjectOfType<PlayerHPUI>();

        palette.CollisionMarble(AgentAttackState.RED);
        palette2.CollisionMarble(AgentAttackState.RED);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
