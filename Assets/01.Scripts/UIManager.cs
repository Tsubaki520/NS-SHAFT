using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Menu")]
    public GameObject Menu = null;
    [SerializeField]
    private Button m_startButton = null;
    [SerializeField]
    private Button m_exitButton = null;

    void Start ()
    {
        Init ();
        GameManager.UIReady = true;
    }

    void Init ()
    {
        Menu.SetActive (true);
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        ButtonListener ();
    }

    void ButtonListener ()
    {
        m_startButton.onClick.AddListener (LoadScene);
        m_exitButton.onClick.AddListener (ExitGame);
    }

    void LoadScene ()
    {
        if (Player.isDead)
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        else
        {
            Menu.SetActive (false);
            GameManager.Instance.GameStatus = Status.Play;
            GameManager.Instance.PlayerActive (true);
        }
    }

    void ExitGame ()
    {
        System.GC.Collect ();
        Application.Quit ();
    }
}
