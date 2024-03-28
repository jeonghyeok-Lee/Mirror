using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [Header("Information")]
    [Tooltip("The name that will be displayed in the UI for this item")]
    public string itemName; 
    public Sprite itemIcon;
    
    [Header("Audio & Visual")]
    public GameObject impactVFX;
    public float impactVFXLifeTime; // 지속시간

    public bool isActive;   // 활성화 여부
    public bool isUsable;   // 사용 가능 여부


    /// <summary>
    /// 아이템을 사용할 때 호출되는 함수
    /// </summary>
    public virtual void UseItem()
    {
        
    }
}
