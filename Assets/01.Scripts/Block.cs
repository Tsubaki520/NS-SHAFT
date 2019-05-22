using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 0;
    private float m_topBorder = 3.6f;

    private Animator animator;
    private BoxCollider2D col;
    public BlockType blockType;

    void Start ()
    {
        animator = GetComponent<Animator> ();
        col = GetComponent<BoxCollider2D> ();
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
        {
            transform.Translate (Vector3.up * m_moveSpeed * Time.deltaTime);
            if (transform.position.y >= m_topBorder)
            {
                GameManager.Instance.BlockCreater.ReturnList (gameObject);
                GameManager.Instance.UIcounter.AddStage (1);
            }
            if (GameManager.Instance.GameStatus == Status.Over)
                gameObject.SetActive (false);
        }
    }

    void AddHP ()
    {
        Player.HP++;
        if (Player.HP >= 10)
            Player.HP = 10;
        GameManager.Instance.UIcounter.SetHP (0);
    }

    void MinusHP ()
    {
        Player.HP -= 3;
        if (Player.HP <= 0)
            Player.HP = 0;
        GameManager.Instance.UIcounter.SetHP (1);
    }

    void AddSpeed ()
    {
        GameManager.Instance.PlayerClone.transform.position += new Vector3 (m_moveSpeed / 10, 0, 0);
    }

    void MinusSpeed ()
    {
        GameManager.Instance.PlayerClone.transform.position += new Vector3 (-m_moveSpeed / 10, 0, 0);
    }

    void AddHeight ()
    {
        GameManager.Instance.PlayerClone.transform.position += new Vector3 (0, m_moveSpeed / 10, 0);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            switch ((int) blockType)
            {
                case (int) BlockType.Fake:
                    {
                        AddHP ();
                        animator.SetTrigger ("OnTriggerEnter");
                        col.isTrigger = true;
                        break;
                    }
                case (int) BlockType.Nails:
                    {
                        MinusHP ();
                        break;
                    }
                default:
                    {
                        AddHP ();
                        break;
                    }
            }
        }
    }

    private void OnCollisionStay2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            switch ((int) blockType)
            {
                case (int) BlockType.Conveyor_Left:
                    {
                        MinusSpeed ();
                        break;
                    }
                case (int) BlockType.Conveyor_Right:
                    {
                        AddSpeed ();
                        break;
                    }
                case (int) BlockType.Trampoline:
                    {
                        AddHP ();
                        AddHeight ();
                        animator.SetTrigger ("OnTriggerEnter");
                        GameManager.Instance.PlayerClone.GetComponent<Player> ().SetTrigger (true);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
