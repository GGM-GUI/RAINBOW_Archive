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
        // ��ȣ�ۿ��� ������ ���¿��� spaceŰ�� ������ ����
        base.InteractionEnter();
        
        // ��ȣ�ۿ��� ������ ���� �� �Ʒ���
        ColorBlue();

        // ��ȣ�ۿ��� ������ �� ������ ������ �Ʒ��� ���� �Ű������� �־���
        InteractionEnd(() =>
        {
            ColorBlack();
            print("endCallback");
        });
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        // ������ ������ ���� ������ �޾ƿ� action���� EndCallbackAction�̶�� �̺�Ʈ�� �־���
        EndCallbackAction = endCallback;

        // �θ��� InteractionEnd�� ����Ǵ� ���� �� 32�� �Ʒ� �־�� ��
        base.InteractionEnd();        
    }

    public override void InteractionExit()
    {
        // �ش� ������Ʈ�� ��ȣ�ۿ� �������� ����� �� ����
        // (��ȣ�ۿ� ǥ��)
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
