using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    [SerializeField]
    private Image[ ] LifeList;
    [SerializeField]
    private Sprite[ ] LifeSprites;
    [SerializeField]
    private Image[ ] StageList;
    [SerializeField]
    private Sprite[ ] Numbers;

    private int m_playerHP = 10;
    private int m_stageNum = 0;

    void Start ()
    {
        for (int x = 0 ; x < LifeList.Length ; x++)
            LifeList[x].sprite = LifeSprites[0];
        for (int y = 0 ; y < StageList.Length ; y++)
            StageList[y].sprite = Numbers[m_stageNum];
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
        {

        }
    }

    public void AddStage (int stage)
    {
        m_stageNum += stage;
    }

    void SetHP ()
    {
        m_playerHP = Player.HP;

    }
}
