using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ドラッグしてオブジェクトを動かす
/// </summary>
public class DragMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{
    bool isDragging = false;

    public void OnBeginDrag( PointerEventData data )
    {
        isDragging = true;
    }

    public void OnDrag( PointerEventData data )
    {
        //ドラッグによる位置移動
        transform.position = transform.position + new Vector3( data.delta.x, data.delta.y );
    }

    public void OnEndDrag( PointerEventData data )
    {
        isDragging = false;
    }

    //ドラッグ中はレイキャストを無視する
    //そうしないと、裏側にあるオブジェクトにレイがあたらず、ドロップイベントを受けることができない
    public bool IsRaycastLocationValid( Vector2 sp, Camera eventCamera )
    {
        return !isDragging;
    }
}
