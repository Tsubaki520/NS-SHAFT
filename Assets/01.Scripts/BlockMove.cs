using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 0;

    void Update ()
    {
        transform.Translate (Vector3.up * m_moveSpeed * Time.deltaTime);
    }
}
