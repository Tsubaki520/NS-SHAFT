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
    public GameObject PlayerClone = null;

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
        GameStatus = Status.Over;
        PlayerClone = Instantiate (Player.gameObject);
        PlayerClone.SetActive (false);
    }

    private void Update ()
    {
        if (Player.isDead)
        {
            GameStatus = Status.Over;
            UI.Menu.SetActive (true);
        }
    }

    public void PlayerActive (bool active)
    {
        PlayerClone.SetActive (active);
    }

    private void OnDestroy ()
    {
        Instance = null;
    }
}
