using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Status GameStatus;

    public BlockCreater BlockCreater;
    public Player Player;
    public UIManager UI;
    public UICounter UIcounter;
    public AudioManager AudioManager;
    private GameObject m_playerClone = null;

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
        m_playerClone = Instantiate (Player.gameObject);
        m_playerClone.SetActive (false);
    }

    private void Update ()
    {
        if (Player.isDead)
        {
            GameStatus = Status.Over;
            Player.GoDie ();
            UI.Menu.SetActive (true);
        }
    }

    public void PlayerActive (bool active)
    {
        m_playerClone.SetActive (active);
    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
