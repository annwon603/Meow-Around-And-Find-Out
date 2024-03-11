
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
    public GameObject QuestBox;
    public GameObject nextNPC;
    public GameObject prevNPC;
    //Accessing to chatbox
    public GameObject dialouge;
    //Accessing to index to list of dialouge
    public int Type; 
    public GameObject[] listOfDialouges;
    //int i for beginning of dialouge
    public int currDialouge = 0;
    //int j for last dialouge
    public int lastDialouge;
    public int currHiddenDialouge;
    //int k for last hiddenDialouge
    public int lastHiddenDialouge;
    public bool canTalk;
    //The chosen dialouge to put into chat box
    GameObject theChoseOne;
    GameObject prevDialouge;
    private bool canClick;
    //If the player need to go back to the NPC for another quest
    public bool isRepeatable;
    //Check if event is complete
    public bool isFunEventComplete;
    public bool canPickItem = false;
    public bool itemReceived = false;
    
    bool onlyUpdateOnce = false;

    int starter;

    void Start()
    {
        dialouge.SetActive(false);
        theChoseOne = listOfDialouges[currDialouge];
        theChoseOne.SetActive(false);
    }

    void Update()
    {
        canClick = (bool)theOtherScript.GetProgramVariable("isPlayerThere");
        theChoseOne = listOfDialouges[currDialouge];
        if(currDialouge > 0){
            prevDialouge = listOfDialouges[currDialouge - 1];
        }
        starter = (int) manageQuest.GetProgramVariable("alreadySet");


    }

    public override void Interact()
    {
        Debug.Log(canClick);

        if(canClick == true && canTalk == true){
            Debug.Log("You're talking to NPC");
            //If you talk to the nail tech 
            // if(Type == 0){
            //     setIsFunComplete(true);
            // }
            setTalk(true);
            // if(Type == 0 && starter == 1){
            //     Debug.Log("Can't talk to butcher bc you talked to beekeeper first");
            //     Debug.Log("Must wait till you finish delivering charm");
            // }else if(Type == 1 && starter == 0){

            //     Debug.Log("Can't talk to beekeeper bc you talked to butcher first");
            //     Debug.Log("Must wait till you deliever bones to fortune teller");

            // }else{
                dialouge.SetActive(true);
                if(currDialouge < lastDialouge + 1){
                    if(currDialouge == 0){
                        currDialouge++;
                        theChoseOne.SetActive(true);
                    }else{
                        theChoseOne.SetActive(true);
                        prevDialouge.SetActive(false);
                        currDialouge++;

                    }
                //Once reach the last dialouge
                }else{
                    dialouge.SetActive(false);
                    theChoseOne.SetActive(false);
                    prevDialouge.SetActive(false);
                    currDialouge = 0;
                    if(Type == 0){
                        quest.setPointer(0);
                    }else if(Type == 1){
                        quest.setPointer(2);
                    }else if(onlyUpdateOnce == false){
                        quest.UpdatePointer();
                        onlyUpdateOnce = true;
                    }
                    QuestBox.SetActive(true);
                    canPickItem = true;
                }
            // }
            
            //Think the nail tech as the head, so once player interact with 
            //beekeeper
            // if(prevNPC.GetComponent<NPCInteract>().Type == 0){
            //     setIsFunComplete(true);
            // }
        }

    }
 
    public void setTalk(bool ReadyToTalk)
    {
        prevNPC.GetComponent<NPCInteract>().canTalk = false;
        // if(nextNPC.GetComponent<NPCInteract>().isRepeatable == true && (Type != 0) ){
        //     nextNPC.GetComponent<NPCInteract>().Type = 4;
        //     nextNPC.GetComponent<NPCInteract>().nextNPC = GameObject.Find("Butcher");
        // }
        if(nextNPC.GetComponent<NPCInteract>().Type == 1){

            nextNPC.GetComponent<NPCInteract>().canTalk = true;
        }

    }

    public void setIsFunComplete(bool fun)
    {
        if(fun == true){
            isFunEventComplete = fun;
            quest.Increase();
        }
    }

   

}
