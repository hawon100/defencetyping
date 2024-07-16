using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convers : MonoBehaviour
{
    public NPCConversation con;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(con);
    }
}
