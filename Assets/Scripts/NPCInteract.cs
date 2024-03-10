
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using UnityEngine.UI;

public class NPCInteract : UdonSharpBehaviour
{
    //Accessing to Detection script
    public UdonBehaviour theOtherScript;
    public NPCDetection script; 

    //Accessing to the QuestManager
    public UdonBehaviour manageQuest;
    public QuestManager quest;

    public GameObject nextNPC;
    public GameObject prevNPC;

    //Accessing to chatbox
    public GameObject dialouge;

    //Accessing to index to list of dialouge
    public int Type; 

    int questUpdate;
    public GameObject[] listOfDialouges;

    public bool canTalk;

    //The chosen dialouge to put into chat box
    GameObject theChoseOne;
    private bool canClick;

    bool hasClick = false;
    void Start()
    {
        dialouge.SetActive(false);
        theChoseOne = listOfDialouges[Type];
        questUpdate = Type + 1;
        

        theChoseOne.SetActive(false);
    }

    void Update()
    {
        canClick = (bool)theOtherScript.GetProgramVariable("isPlayerThere");
        theChoseOne = listOfDialouges[Type];


    }

    public override void Interact()
    {
        Debug.Log(canClick);
        if(hasClick == false && canClick == true && canTalk == true){
            Debug.Log("You're talking to NPC");
            
            quest.set(questUpdate);
            setTalk(true);
            dialouge.SetActive(true);
            theChoseOne.SetActive(true);
            hasClick = true;
        }else{
            dialouge.SetActive(false);
            theChoseOne.SetActive(false);
            hasClick = false;
        }

    }

    public void setTalk(bool ReadyToTalk)
    {
        nextNPC.GetComponent<NPCInteract>().canTalk = ReadyToTalk;
        prevNPC.GetComponent<NPCInteract>().canTalk = false;
        
    }

}
