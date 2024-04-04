using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템을 관리하는 클래스
/// </summary>
public class ItemManager : MonoBehaviour
{
    /// <summary>
    /// 아이템 활성화 여부를 설정하는 함수
    /// </summary>
    /// <param name="show"></param>
    public void ShowItem(BaseItem item, bool show)
    {
        item.gameObject.SetActive(show);
        item.isActive = show;
    }
}
