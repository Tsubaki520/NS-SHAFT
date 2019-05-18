using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speedX;
    private Rigidbody2D m_rb;
    private CircleCollider2D m_col;
    private Animator m_animator;

    public static bool isDead;
    public static int HP;

    private float m_directionX;
    private bool m_isLeft = false;
    private bool m_isStop = false;

    private void Awake ()
    {
        isDead = false;
        HP = 10;
        m_speedX = 300;
        m_rb = GetComponent<Rigidbody2D> ();
        m_col = GetComponent<CircleCollider2D> ();
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

        CheckDirection ();
    }

    void CheckDirection ()
    {
        if (m_directionX < 0)
        {
            m_isLeft = true;
            m_isStop = false;
        }
        else if (m_directionX > 0)
        {
            m_isLeft = false;
            m_isStop = false;
        }
        else
            m_isStop = true;
    }

    public void GoDie ()
    {
        gameObject.SetActive (false);
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

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag ("Ceiling"))
            StartCoroutine (SetTrigger (true));
    }

    IEnumerator SetTrigger (bool isTrigger)
    {
        m_col.isTrigger = isTrigger;
        yield return new WaitForFixedUpdate ();
        m_col.isTrigger = !isTrigger;
        yield return null;
    }
}
