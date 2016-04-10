using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Y座標によって表示順を変える（クォータービュー的なゲームに使う）
/// </summary>
public class SortSiblingIndexByPositionY : MonoBehaviour
{
    public List<RectTransform> sortTrasforms;
    public int topSiblingIndex = 0;

    public void Sort()
    {
        //Y値が高い順に並び替える
        sortTrasforms.Sort( (a, b ) => ( -a.position.y.CompareTo( b.position.y ) ) );

        int index = topSiblingIndex;
        foreach( RectTransform sortTrasform in sortTrasforms )
        {
            sortTrasform.SetSiblingIndex( index++ );
        }
    }
}
