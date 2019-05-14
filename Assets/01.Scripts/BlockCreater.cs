using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour
{
    [Header ("Object Spawn Settings")]
    [SerializeField]
    private Transform m_ObjectTransform;
    [SerializeField]
    private GameObject[ ] m_blockList = null;
    [SerializeField]
    private float m_initHeight = 0;
    public bool canSpawn;

    readonly float m_borderLeft = -7.75f;
    readonly float m_borderRight = 5.5f;

    private void Start ()
    {
        for (int i = 0 ; i < transform.childCount ; i++)
        {
            m_blockList[i] = transform.GetChild (i).gameObject;
        }
    }

    string NewBlockType ()
    {
        int Type = Random.Range (0, m_blockList.Length);
        m_ObjectTransform = m_blockList[Type].transform;
        return m_blockList[Type].name;
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
        if (canSpawn)
            StartCoroutine (CreateBlock ());
    }

    IEnumerator CreateBlock ()
    {
        Transform t = ObjectPool.Instance.TakeFromPool (NewBlockType ());
        if (t = null) yield return null;

        t.SetParent (m_ObjectTransform);
        t.SetPositionXY (NewBlockPositionX (), NewBlockPositionY ());
        t.rotation = m_ObjectTransform.rotation;
        yield return new WaitForSeconds (1);
    }
}
