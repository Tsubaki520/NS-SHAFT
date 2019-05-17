using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Status GameStatus;

    public BlockCreater blockCreater;
    public Player player;
    public UIManager UI;

    public static GameManager Instance = null;
    public static bool PlayerReady, PoolReady, UIReady;
    /// <summary>
    /// 所有關卡系統準備完成
    /// </summary>
    public static bool SceneReady
    {
        get { return PlayerReady && PoolReady && UIReady; }
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
        GameStatus = Status.Over;
        blockCreater = GameObject.FindGameObjectWithTag ("Respawn").GetComponent<BlockCreater> ();
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        UI = GameObject.FindGameObjectWithTag ("UIManager").GetComponent<UIManager> ();
    }

    private void Update ()
    {
        if (Player.isDead)
        {
            GameStatus = Status.Over;
            player.GoDie ();
            UI.Menu.SetActive (true);
        }
    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
