using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Quest,              // 퀘스트
    Immediate,          // 즉시 사용
    Persistent,         // 지속 사용
}

public class BaseItem : MonoBehaviour
{
    [Header("Information")]
    [Tooltip("The name that will be displayed in the UI for this item")]
    public string itemName; 
    public Sprite itemIcon;
    public ItemType itemType;               // 아이템 타입
    public string itemDescription;          // 아이템 설명
    
    [Header("Item Paarmeters")]
    public float delayBetweenUse = 0.5f;    // 사용 간격

    [Header("Audio & Visual")]
    public GameObject impactVFX;
    public float impactVFXLifeTime;         // 지속시간

    public bool isActive;                   // 활성화 여부
    public bool isUsable;                   // 사용 가능 여부

    /// <summary>
    /// 아이템을 사용할 때 호출되는 함수
    /// </summary>
    public abstract void UseItem();

    /// <summary>
    /// 아이템 활성화 여부를 설정하는 함수
    /// </summary>
    /// <param name="show"></param>
    public void ShowItem(bool show)
    {
        gameObject.SetActive(show);
        isActive = show;
    }
}
