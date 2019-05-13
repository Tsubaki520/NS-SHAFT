using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    private RectTransform rect;

    [Header ("ScrollSetting")]
    [SerializeField]
    private float scrollSpeed = 0.4f;
    [SerializeField]
    private float imageHeight;
    [SerializeField]
    private float initPositionY;

    void Start ()
    {
        rect = GetComponent<RectTransform> ();
        imageHeight = rect.sizeDelta.y;
        initPositionY = -imageHeight * 2;
    }

    void Update ()
    {
        Scroll ();
    }

    void Scroll ()
    {
        GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0, 100 * Time.deltaTime * scrollSpeed);
        if (rect.anchoredPosition.y >= imageHeight)
        {
            rect.anchoredPosition += new Vector2 (0, initPositionY);
        }
    }
}
