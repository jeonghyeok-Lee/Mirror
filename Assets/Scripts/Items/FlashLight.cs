using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light flashLight = null;   // 라이트

    // 나중에는 [SerializeField]를 제거할 예정
    [SerializeField] private bool isOn = false;  // 라이트의 상태
    [SerializeField] private float lightIntensity = 15.0f;   // 라이트의 밝기 (현재)
    [SerializeField] private float lightDistance = 10.0f;   // 라이트의 거리 (현재)

    void Start()
    {
        if (flashLight == null)
        {
            flashLight = GameObject.Find("Flash").GetComponent<Light>();
        }
    }


    public void SetFlashLight()
    {
        flashLight.enabled = isOn;                  // 라이트의 상태를 설정
        flashLight.intensity = lightIntensity;      // 라이트의 밝기를 설정
        flashLight.range = lightDistance;           // 라이트의 거리를 설정
    }

    /// <summary>
    /// 라이트의 밝기 값을 전달 받아 라이트의 밝기를 조절하는 함수
    /// </summary>
    /// <param name="intensity">빛의 세기</param>
    public void ChangeLightIntensity(float intensity)
    {
        // 추후 최대치 최소치 제한을 추가 해야함
        lightIntensity = intensity;
        flashLight.intensity = lightIntensity;
    }

    /// <summary>
    /// 현재 라이트의 온오프 여부에 따라 라이트를 켜고 끄는 함수
    /// </summary>
    public void LightOnOff()
    {
        isOn = !isOn;
        flashLight.enabled = isOn;
    }

}
