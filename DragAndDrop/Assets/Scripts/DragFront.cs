using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ドラッグした時に、兄弟オブジェクトの一番手前に描画する
/// </summary>
public class DragFront : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //ドラッグ終了後インデックスを元に戻すか
    public bool isRestoreIndex;
    //元に戻すときのために、インデックスを記録しておく
    int siblingIndex;

    //ドラッグ開始時に、描画インデックスを一番手前にもってくる
    //OnBeginDragではなくOnPointerDownを使うのは、
    //タッチダウンしたときにすぐに描画順が変わるようにするため
    public void OnPointerDown( PointerEventData data )
    {
        siblingIndex = this.transform.GetSiblingIndex();
        this.transform.SetAsLastSibling();
    }

    //ドラッグ終了、インデックスを一番手前にもってくる
    public void OnPointerUp( PointerEventData data )
    {
        if( isRestoreIndex )
        {
            this.transform.SetSiblingIndex( siblingIndex );
        }
    }
}
