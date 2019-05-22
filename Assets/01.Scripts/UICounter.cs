using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    [SerializeField]
    private Image[ ] LifeList = null;
    /// <summary> 0 = 滿血, 1 = 扣血 </summary>
    [SerializeField]
    private Sprite[ ] LifeSprites = null;
    [SerializeField]
    private Image[ ] StageList = null;
    [SerializeField]
    private Sprite[ ] Numbers = null;

    private int m_nowHP = 10;
    private int m_stageNum = 0;

    void Start ()
    {
        for (int x = 0 ; x < LifeList.Length ; x++)
            LifeList[x].sprite = LifeSprites[0];
        for (int y = 0 ; y < StageList.Length ; y++)
            StageList[y].sprite = Numbers[m_stageNum];
    }

    public void AddStage (int stage)
    {
        m_stageNum += stage;
        for (int i = 0 ; i < StageList.Length ; i++)
            StageList[i].sprite = Numbers[(m_stageNum / (int) Mathf.Pow (10, i)) % 10];
    }

    /// <summary> 0 = 補血, 1 = 扣血 </summary>
    public void SetHP (int hpSprite)
    {
        m_nowHP = Player.HP;
        if (hpSprite == 0)
            LifeList[m_nowHP - 1].sprite = LifeSprites[hpSprite];
        else
            for (int i = m_nowHP ; i < LifeList.Length ; i++)
                LifeList[i].sprite = LifeSprites[hpSprite];
    }
}
