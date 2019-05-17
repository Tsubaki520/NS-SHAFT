using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speedX;
    private Rigidbody2D m_rb;
    private Animator m_animator;

    public static bool isDead;
    public static int HP;

    private float m_directionX;

    void Start ()
    {
        isDead = false;
        HP = 10;
        m_speedX = 300;
        m_rb = GetComponent<Rigidbody2D> ();
        m_animator = GetComponent<Animator> ();
        GameManager.PlayerReady = true;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
        {
            Move ();
        }
    }

    void Move ()
    {
        m_directionX = Input.GetAxisRaw ("Horizontal");
        m_rb.velocity = Vector2.right * m_directionX * Time.deltaTime * m_speedX;
    }

    public void GoDie ()
    {

    }

    void CheckLife ()
    {

    }

    void PlayAni (int index)
    {
        switch (index)
        {
            default:
                {
                    break;
                }
        }
    }
}
