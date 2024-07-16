using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convers : MonoBehaviour
{
    public NPCConversation con;

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(con);
        }
    }
}
