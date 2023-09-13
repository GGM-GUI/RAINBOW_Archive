using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public CinemachineVirtualCamera virCam;
    private CinemachineBasicMultiChannelPerlin noise;
    private Tweener tweener;
    public float shakeCam = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        noise = virCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    //private void Update()
    //{
    //    noise.m_AmplitudeGain = shakeCam;
    //    Debug.Log(shakeCam);
    //}
    public void Shake(float t, float p)
    {
        Debug.Log("카메라 흔들림");
        if (tweener != null && tweener.IsActive())
        {
            tweener.Kill();
        }
        float currentValue = p;
        tweener = DOTween.To(() => currentValue, x => currentValue = x, 0, t).SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                shakeCam = currentValue;
            });
    }
}
