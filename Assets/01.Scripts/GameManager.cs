using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockCreater blockCreater;

    public static GameManager Instance = null;
    public static bool PoolReady, UIReady;
    /// <summary>
    /// 所有關卡系統準備完成
    /// </summary>
    public static bool SceneReady
    {
        get { return PoolReady && UIReady; }
    }

    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad (gameObject);
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
        blockCreater.canSpawn = false;
    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
