using UnityEngine;
using UnityEngine.UI;

public class Wallace : MonoBehaviour
{
    public GameObject targetGameObject; // 이미지가 생성될 GameObject
    public Canvas canvas; // 이미지가 생성될 Canvas
    public Sprite imageSprite; // 생성할 이미지의 스프라이트

    void Start()
    {
        // targetGameObject의 화면 좌표 계산
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, targetGameObject.transform.position);

        // Canvas에 이미지 생성
        GameObject imageObject = new GameObject("SpawnedImage");
        imageObject.transform.SetParent(canvas.transform);

        // RectTransform 설정
        RectTransform rectTransform = imageObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 100); // 이미지 크기 설정
        rectTransform.anchoredPosition = screenPosition - new Vector2(Screen.width / 2, Screen.height / 2); // 화면 좌표를 Canvas 좌표로 변환

        // 이미지 설정
        Image image = imageObject.AddComponent<Image>();
        image.sprite = imageSprite;
    }
}
