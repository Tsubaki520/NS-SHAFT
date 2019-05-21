using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 0;
    private float m_topBorder = 3.6f;

    public BlockType blockType;

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
        }
    }

    void AddHP ()
    {
        Player.HP++;
        if (Player.HP >= 10)
            Player.HP = 10;
    }

    void MinusHP ()
    {
        Player.HP -= 3;
        if (Player.HP <= 0)
            Player.HP = 0;
    }

    void AddSpeed ()
    {
        GameManager.Instance.Player.transform.AddPositionX (m_moveSpeed);
    }

    void MinusSpeed ()
    {
        GameManager.Instance.Player.transform.AddPositionX (-m_moveSpeed);
    }

    void AddHeight ()
    {
        GameManager.Instance.Player.transform.AddPositionY (m_moveSpeed);
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
                        break;
                    }
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
}
