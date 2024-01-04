using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private FlashLight flashLight;  // 플래시 라이트

        [SerializeField] private StarterAssetsInputs _input;

        private bool _prevFlashLightState = false; // 이전 프레임의 플래시 라이트 상태

        void Update()
        {
            // 플래시 라이트의 상태를 설정[실시간 변경을 위한 테스트 함수]
            // 추후 모든 설정이 완료되면 사라질 함수
            flashLight.SetFlashLight(); 

            HandleFlashLight();

        }

        private void HandleFlashLight()
        {
            // 이전 프레임과 현재 프레임의 플래시 라이트 상태가 같으면 리턴
            if(_prevFlashLightState == _input.flashLightState) { return; }  

            flashLight.LightOnOff();
            _prevFlashLightState = _input.flashLightState;
        }


    }
}