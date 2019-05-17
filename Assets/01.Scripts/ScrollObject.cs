using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField]
    private bool canLoop = false;
    private RectTransform rect;

    [Header ("ScrollSetting")]
    [SerializeField]
    private float imageHeight;
    [SerializeField]
    private float initPositionY;
    private float scrollSpeed = 40;

    void Start ()
    {
        rect = GetComponent<RectTransform> ();
        imageHeight = rect.sizeDelta.y;
        initPositionY = -imageHeight * 2;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        Scroll ();
    }

    void Scroll ()
    {
        GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0, Time.deltaTime * scrollSpeed);

        if (canLoop && rect.anchoredPosition.y >= imageHeight)
        {
            rect.anchoredPosition += new Vector2 (0, initPositionY);
        }
    }
}
