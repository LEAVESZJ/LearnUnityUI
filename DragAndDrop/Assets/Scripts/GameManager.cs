using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ドラッグアンドドロップのサンプルゲームの全体制御
/// </summary>
public class GameManager : MonoBehaviour
{
    public SortSiblingIndexByPositionY sortSiblingIndex;
    bool isDroped;

    //ドラッグ開始
    public void OnBeginDrag( BaseEventData data )
    {
        Animator animator = ( (PointerEventData)data ).pointerDrag.GetComponent<Animator>();
        animator.SetTrigger( "DragTrigger" );
        isDroped = false;
    }

    // ドロップされた
    public void OnDrop( BaseEventData data )
    {
        isDroped = true;
    }

    // ドラッグが終わった
    public void OnEndDrag( BaseEventData data )
    {
        Animator animator = ( (PointerEventData)data ).pointerDrag.GetComponent<Animator>();
        if( isDroped )
        {
            animator.SetTrigger( "SmileTrigger" );
        }
        else
        {
            animator.SetTrigger( "IdleTrigger" );
        }
        sortSiblingIndex.Sort();
        isDroped = false;
    }
}
