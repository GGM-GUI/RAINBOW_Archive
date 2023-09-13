using System;
using UnityEngine;

public class InteractionSample : InteractionAble
{
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public override void InteractionEnter()
    {
        // 상호작용이 가능한 상태에서 space키를 누르면 실행
        base.InteractionEnter();
        
        // 상호작용을 무엇을 할지 이 아래에
        ColorBlue();

        // 상호작용이 끝났을 때 무엇을 할지를 아래와 같이 매개변수로 넣어줌
        InteractionEnd(() =>
        {
            ColorBlack();
            print("endCallback");
        });
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        // 끝나고 무엇을 할지 위에서 받아온 action들을 EndCallbackAction이라는 이벤트에 넣어줌
        EndCallbackAction = endCallback;

        // 부모의 InteractionEnd가 실행되는 것이 위 32줄 아래 있어야 함
        base.InteractionEnd();        
    }

    public override void InteractionExit()
    {
        // 해당 오브젝트의 상호작용 범위에서 벗어났을 때 실행
        // (상호작용 표시)
        base.InteractionExit();
    }

    public void ColorBlue()
    {
        _spriteRenderer.color = Color.blue;
    }

    public void ColorBlack()
    {
        _spriteRenderer.color = Color.black;
    }
}
