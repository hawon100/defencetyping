using UnityEngine;
using UnityEngine.UI;

public class Wallace : MonoBehaviour
{
    public GameObject targetGameObject; // �̹����� ������ GameObject
    public Canvas canvas; // �̹����� ������ Canvas
    public Sprite imageSprite; // ������ �̹����� ��������Ʈ

    void Start()
    {
        // targetGameObject�� ȭ�� ��ǥ ���
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, targetGameObject.transform.position);

        // Canvas�� �̹��� ����
        GameObject imageObject = new GameObject("SpawnedImage");
        imageObject.transform.SetParent(canvas.transform);

        // RectTransform ����
        RectTransform rectTransform = imageObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 100); // �̹��� ũ�� ����
        rectTransform.anchoredPosition = screenPosition - new Vector2(Screen.width / 2, Screen.height / 2); // ȭ�� ��ǥ�� Canvas ��ǥ�� ��ȯ

        // �̹��� ����
        Image image = imageObject.AddComponent<Image>();
        image.sprite = imageSprite;
    }
}
