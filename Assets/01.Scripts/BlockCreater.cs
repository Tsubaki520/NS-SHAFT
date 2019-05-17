using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour
{
    [Header ("Object Spawn Settings")]
    [SerializeField]
    private Transform m_ObjectTransform;
    [SerializeField]
    private GameObject[ ] m_blockList;
    private List<GameObject> m_UsedBlockList = new List<GameObject> (BlockNum);
    private List<GameObject> m_unUsedBlockList = new List<GameObject> (BlockNum);
    [SerializeField]
    private float m_initHeight = 0;
    const int BlockNum = 120;

    //BorderLimit
    readonly float m_borderLeft = -7.75f;
    readonly float m_borderRight = 5.5f;

    void Start ()
    {
        SetObjectPool ();
    }

    void SetObjectPool ()
    {
        for (int i = 0 ; i < transform.childCount ; i++)
        {
            m_blockList[i] = transform.GetChild (i).gameObject;
            GameObject block = Instantiate (m_blockList[i], m_blockList[i].transform);

            for (int x = 0 ; x < BlockNum ; x++)
            {
                m_unUsedBlockList.Add (block);
                block.SetActive (false);
            }
        }
    }

    float NewBlockPositionX ()
    {
        return Random.Range (m_borderLeft, m_borderRight);
    }

    float NewBlockPositionY ()
    {
        return m_ObjectTransform.position.y - m_initHeight;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
            StartCoroutine (CreateBlock ());
    }

    IEnumerator CreateBlock ()
    {
        int Type = Random.Range (0, m_blockList.Length);
        int Index = m_unUsedBlockList.Count - 1;
        if (Index > 0)
        {
            var block = m_unUsedBlockList[Index];
            m_unUsedBlockList.RemoveAt (Index);
            m_UsedBlockList.Add (block);
            block.SetActive (true);
        }
        /*
        string m_blockType = m_blockList[Type].name;
        m_ObjectTransform = m_blockList[Type].transform;
        Transform t = ObjectPool.Instance.TakeFromPool (m_blockType);
        if (t = null) yield return null;

        float posX = Random.Range (m_borderLeft, m_borderRight);
        float posY = m_ObjectTransform.position.y - m_initHeight;
        //t.SetPositionAndRotation (new Vector2 (posX, posY), m_ObjectTransform.rotation);
        //t.rotation = m_ObjectTransform.rotation;
        */
        yield return new WaitForSeconds (1);
    }
}
