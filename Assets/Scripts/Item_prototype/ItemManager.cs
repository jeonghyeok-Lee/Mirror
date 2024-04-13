using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템을 관리하는 클래스
/// </summary>
public class ItemManager : MonoBehaviour
{
    private static ItemManager _itemManager;              // 싱글톤 인스턴스
    public static ItemManager Instance => _itemManager;   // 인스턴스 접근용 프로퍼티

    public List<BaseItem> items;
    
    void Awake(){
        // 싱글톤 인스턴스 설정
        if(_itemManager == null){
            _itemManager = this;                            // 인스턴스 할당
            DontDestroyOnLoad(gameObject);                  // 씬 전환 시에도 파괴되지 않도록 설정
        }
        else{
            Destroy(gameObject);
        }

        items = new List<BaseItem>();
        
        // 모든 BaseItem 타입의 객체를 찾아서 리스트에 추가
        BaseItem[] allBaseItems = Resources.FindObjectsOfTypeAll<BaseItem>();
        foreach (BaseItem item in allBaseItems){
            items.Add(item);
            ShowItem(item, true);
        }
    }

    /// <summary>
    /// 아이템 활성화 여부를 설정하는 함수
    /// </summary>
    /// <param name="show"></param>
    public void ShowItem(BaseItem item, bool show){
        if(show){
            item.Activate();
        }
        else{
            item.Deactivate();
        }
    }
}
