using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Triggered;
    public QuestState state = QuestState.None;

    public enum QuestState {
        None, InProgress, Completed
    }

    void Start()
    {
        Triggered = false;
        state = QuestState.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "NPC 1" && state == QuestState.None && !Triggered) {
            NoneQuestState();
        }
        else if (other.tag == "NPC 1" && state == QuestState.InProgress && !Triggered) {
            InProgressQuestState();
        }
        else if (!Triggered && other.tag == "Treasure") {
            Triggered = true;
            CompletedQuestState();
        }

        if (other.tag == "Line 1") {
            Debug.Log("*** Guard: You have made it past the maze. Your next task is to complete this puzzle. ***");
        }

        if (other.tag == "Line 2") {
            Debug.Log("*** Guard: Congratulations on solving the puzzle. The next task is dangerous. You'll need to dodge the bullets of the other guards to make it past this stage of your venture. ***");
        }
    }

    public void CheckQuestState() {
        switch (state) {
            case QuestState.None:
                NoneQuestState();
                break;
            case QuestState.InProgress:
                InProgressQuestState();
                break;
            case QuestState.Completed:
                CompletedQuestState();
                break;
        }
    }

    public void NoneQuestState() {
        Debug.Log("*** NPC: Hello traveller. Do you wanna get rich? Go forth and retrieve a treasure. And, I'll teach you how to invest in stock with that treasure if you give me a percentage of it. You can start by rotating behind. Good luck! ***");
        Destroy(GameObject.Find("PreGameWall"));
        state = QuestState.InProgress;
    }

    public void InProgressQuestState() {
        Debug.Log("*** NPC: You're engaging in tomfoolery. Utilize more effort into retrieving the treasure. ***");
    }

    public void CompletedQuestState() {
        gameObject.transform.position = new Vector3(0f, 0.4f, -4f);
        GameObject.FindWithTag("Treasure").transform.position = new Vector3(-2f, 0f, -6f);
        transform.Rotate(0, 180, 0);
        Debug.Log("*** NPC: Amazing work! You're now on the road to riches my friend! Alright, so we'll be following an NFT investment scheme to be RICH! ***");
    }
}