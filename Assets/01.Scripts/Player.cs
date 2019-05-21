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

    private void Awake ()
    {
        isDead = false;
        HP = 10;
        m_speedX = 300;
        transform.position = new Vector3 (-1, 0, 1);
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
            PlayAni ((int) AnimationType.Left);
        }
        else if (m_directionX > 0)
        {
            PlayAni ((int) AnimationType.Right);
        }
        else
        {
            PlayAni ((int) AnimationType.Idle);
        }
    }

    public void GetHurt ()
    {
        m_animator.SetTrigger ("Hurt");
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
            case 1:
                {
                    m_animator.SetBool ("Input", true);
                    m_animator.SetFloat ("Arrow", m_directionX);
                    break;
                }
            case 2:
                {
                    m_animator.SetBool ("Input", true);
                    m_animator.SetFloat ("Arrow", m_directionX);
                    break;
                }
            default:
                {
                    m_animator.SetBool ("Input", false);
                    break;
                }
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Ceiling"))
            StartCoroutine (SetTrigger (true));
        if (other.gameObject.CompareTag ("Block"))
            m_animator.SetBool ("Fall", false);
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Block"))
            m_animator.SetBool ("Fall", true);
    }

    IEnumerator SetTrigger (bool isTrigger)
    {
        m_col.isTrigger = isTrigger;
        yield return new WaitForFixedUpdate ();
        m_col.isTrigger = !isTrigger;
        yield return null;
    }
}
