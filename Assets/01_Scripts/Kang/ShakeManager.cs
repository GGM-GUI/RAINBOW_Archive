using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class ShakeManager : MonoBehaviour
{
    public static ShakeManager Instance;
    public CinemachineVirtualCamera virCam;
    private CinemachineBasicMultiChannelPerlin noise;
    private Tweener[] tweener = new Tweener[5];
    float[] shakeCam = { 0, 0, 0, 0, 0 };
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        noise = virCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        noise.m_AmplitudeGain = shakeCam[0] + shakeCam[1] + shakeCam[2] + shakeCam[3] + shakeCam[4] + CameraShake.Instance.shakeCam;
    }
    public void Shake(int c, float p)
    {
        if (tweener != null && tweener[c].IsActive())
        {
            tweener[c].Kill();
        }
        float currentValue = p;
        tweener[c] = DOTween.To(() => currentValue, x => currentValue = x, 0, 0.7f).SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                shakeCam[c] = currentValue;
            });
    }
}
