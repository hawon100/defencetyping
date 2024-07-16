using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convers : MonoBehaviour
{
    public NPCConversation con;
    public WaveController wave;

    private void Start()
    {
        if(wave.thisStage.name == "Battle of Okpo")
        {
            ConversationManager.Instance.StartConversation(con);
        }
    }
}
