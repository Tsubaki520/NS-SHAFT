using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public static bool PoolReady, UIReady;
    /// <summary>
    /// 所有關卡系統準備完成
    /// </summary>
    public static bool SceneReady
    {
        get { return PoolReady && UIReady; }
    }

    readonly float m_leftBorder = -7.75f;
    readonly float m_rightBorder = 5.5f;

    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
            return;
        }

        Init ();
    }

    private void Init ()
    {

    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
