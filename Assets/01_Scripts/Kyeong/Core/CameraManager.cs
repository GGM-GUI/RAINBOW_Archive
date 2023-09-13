using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private float _amplitude;
    [SerializeField] private float _duration;
    private CinemachineVirtualCamera _cmVcam;
    private CinemachineBasicMultiChannelPerlin _noise;

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.Log("Multiple CameraManager is running");
    }

    private void Start()
    {
        _cmVcam = GetComponent<CinemachineVirtualCamera>();
        _noise = _cmVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
    }

    public void CameraShake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float time = _duration;
        while (time > 0)
        {
            _noise.m_AmplitudeGain = Mathf.Lerp(0, _amplitude, time / _duration);
            yield return null;
            time -= Time.deltaTime;
        }
        _noise.m_AmplitudeGain = 0;
    }

}
