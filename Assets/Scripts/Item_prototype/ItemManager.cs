using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템을 관리하는 클래스
/// </summary>
public class ItemManager : MonoBehaviour
{
    public List<BaseItem> items;    
    
    void Awake()
    {
        items = new List<BaseItem>();
        
        // 모든 BaseItem 타입의 객체를 찾아서 리스트에 추가
        BaseItem[] allBaseItems = Resources.FindObjectsOfTypeAll<BaseItem>();
        foreach (BaseItem item in allBaseItems)
        {
            items.Add(item);
            ShowItem(item, true);
        }
    }

    /// <summary>
    /// 아이템 활성화 여부를 설정하는 함수
    /// </summary>
    /// <param name="show"></param>
    public void ShowItem(BaseItem item, bool show)
    {
        if(show){
            item.Activate();
        }
        else{
            item.Deactivate();
        }
    }
}
