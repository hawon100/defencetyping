using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoPasteInputField : InputField
{
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        // Clipboard 관련 동작을 무시하기 위해 업데이트 선택 이벤트를 재정의
        if (Input.GetKeyDown(KeyCode.V) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            // Do nothing to disable paste
        }
        else if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            // Do nothing to disable copy
        }
        else if (Input.GetKeyDown(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            // Do nothing to disable copy
        }
        else
        {
            base.OnUpdateSelected(eventData);
        }
    }
}
