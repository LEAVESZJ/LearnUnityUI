using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// 基本チュートリアルの全体制御


public class GameSystem : MonoBehaviour
{
    [SerializeField]
    private InputField nameField;
    [SerializeField]
    private Image playerImage;
    [SerializeField]
    private Slider playerImageScaleSlider;

    [SerializeField]
    private Sprite monsterSprite;
    [SerializeField]
    private Sprite mermanSprite;
    [SerializeField]
    private Sprite robotSprite;

    public enum PlayerType
    {
        Monster,
        Merman,
        Robot
    }

    PlayerType playerType = PlayerType.Monster;

    //アバター画像を反転させるプロパテイ
    //チェックボックスからイベント設定する
    bool isFlipPlayerImage;

    public bool IsFlipPlayerImage
    {
        set
        {
            isFlipPlayerImage = value;
            UpdatePlayerImageScale();
        }
    }

    //画像の表示倍率
    //スライダーからイベント設定する
    float playerImageScale = 1.0f;

    public void ChangePlayerImageScale( float scale )
    {
        playerImageScale = scale;
        UpdatePlayerImageScale();
    }

    //画像の表示倍率・反転の状態を反映
    void UpdatePlayerImageScale()
    {
        Vector3 scale = Vector3.one * ( playerImageScale * 0.4f + 0.6f );
        if( isFlipPlayerImage ) scale.x *= -1.0f;
        playerImage.transform.localScale = scale;
    }

    //デバッグログを出力
    //バックボタンのイベントに設定
    public void Back()
    {
        Debug.Log( "Back" );
    }

    //シーンを読み込みなおす
    //Restボタンのイベントに設定
    public void Reset()
    {
        SceneManager.LoadScene( 0 );
    }

    //デバッグログを出力
    //Submitボタンのイベントに設定
    public void Submit()
    {
        Debug.Log( "Player Name: " + nameField.text );
        Debug.Log( "Player Type: " + playerType.ToString() );
        Debug.Log( "Main Image Scale: " + playerImage.transform.localScale );
    }

    //表示アバターのタイプを設定
    //ラジオボタンから設定する
    public void ChangePlayerType( int index )
    {
        ChangePlayerType( (PlayerType)index );
    }

    public void ChangePlayerType( PlayerType type )
    {
        if( playerType == type ) return;

        playerType = type;
        switch( type )
        {
            case PlayerType.Monster:
                playerImage.sprite = monsterSprite;
                break;
            case PlayerType.Merman:
                playerImage.sprite = mermanSprite;
                break;
            case PlayerType.Robot:
                playerImage.sprite = robotSprite;
                break;
            default:
                break;
        }
        playerImage.SetNativeSize();
        UpdatePlayerImageScale();
    }
}
