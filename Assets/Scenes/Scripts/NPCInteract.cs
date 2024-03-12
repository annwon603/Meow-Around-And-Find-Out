
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
    //Check if event is complete
    public bool isFunEventComplete;
    public bool canPickItem = false;
    public bool itemReceived = false;
    
    public int whenToDestroy;
    bool onlyUpdateOnce = false;
    int starter;

    public bool ifRepeatable = false;

    bool hasStart = false;

    bool hasReset = false;
    public int begIndex = 0;

    
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
        
        //If currDialouge is greater than 0
        if(currDialouge > 0){
            prevDialouge = listOfDialouges[currDialouge - 1];
        }
        starter = (int) manageQuest.GetProgramVariable("alreadySet");


    }

    public override void Interact()
    {
        Debug.Log(canClick);

        if(canClick == true && canTalk == true && hasReset == false){
            Debug.Log("You're talking to NPC");

            // if(currDialouge == 0 && hasStart == false){
            //     dialouge.SetActive(true);
            //     hasStart = true;
            // }

            // if(currDialouge == 0){
            //     begIndex = 0;
            // }else if(currDialouge == currHiddenDialouge){
            //     begIndex = currHiddenDialouge;
            // }

            if(currDialouge == whenToDestroy){
                this.GetComponent<DeleteItem>().Destroy();
            }

            //Iterating through dialouges
            if(currDialouge <= lastDialouge && currDialouge + 1 <= currHiddenDialouge){
                dialouge.SetActive(true);
                theChoseOne.SetActive(true);
                 if(currDialouge == begIndex){
                    currDialouge++;
                    theChoseOne.SetActive(true);
                }else{
                    //checking if the next element is part of the begin of hidden
                    //dialouge
                    // if(currDialouge + 1 == currHiddenDialouge){
                    //     theChoseOne.SetActive(true);
                    //     prevDialouge.SetActive(false);
                    //     currDialouge = begIndex;
                    //     Debug.Log("I have Looped");
                    //     hasReset = true;

                    // }else{
                        currDialouge++;
                        theChoseOne.SetActive(true);
                        prevDialouge.SetActive(false);
                    // }
                }
            //Once finish iteratating
            }else{
                // if(currDialouge == lastDialouge){
                //     currDialouge --;
                // }
                // currDialouge = begIndex;
                // hasReset = false;
                dialouge.SetActive(false);
                theChoseOne.SetActive(false);
                prevDialouge.SetActive(false);
                currDialouge = begIndex;
                if(Type == 0){
                    quest.setPointer(0);
                }else if(Type == 1 && ifRepeatable == false){
                    quest.setPointer(2);
                }else if(onlyUpdateOnce == false){
                    quest.UpdatePointer();
                    onlyUpdateOnce = true;
                }else if(ifRepeatable == true){
                    quest.UpdatePointer();
                }
                Debug.Log("Reached Last Dialouge");
                setTalk(true);

                // hasReset = false;
                QuestBox.SetActive(true);
                canPickItem = true;
            }  
        //Once reach the last dialouge
        }
            
    }
        
    

 
    public void setTalk(bool ReadyToTalk)
    {
        if(ReadyToTalk == true){
            prevNPC.GetComponent<NPCInteract>().canTalk = false;
        }
        // if(nextNPC.GetComponent<NPCInteract>().isRepeatable == true && (Type != 0) ){
        //     nextNPC.GetComponent<NPCInteract>().Type = 4;
        //     nextNPC.GetComponent<NPCInteract>().nextNPC = GameObject.Find("Butcher");
        // }
        if(nextNPC.GetComponent<NPCInteract>().Type == 1){

            nextNPC.GetComponent<NPCInteract>().canTalk = true;
        }

        //If next NPC is wizard and current NPC type is Baker
        if(nextNPC.GetComponent<NPCInteract>().Type == 3 && this.Type == 2){

            //Unlock hidden dialouge for both wizard and beekeeper
            nextNPC.GetComponent<NPCInteract>().currDialouge = 
                nextNPC.GetComponent<NPCInteract>().currHiddenDialouge;

            nextNPC.GetComponent<NPCInteract>().begIndex =
                nextNPC.GetComponent<NPCInteract>().currDialouge;

            
            nextNPC.GetComponent<NPCInteract>().lastDialouge = 
                nextNPC.GetComponent<NPCInteract>().lastHiddenDialouge;
            nextNPC.GetComponent<NPCInteract>().begIndex = 
                nextNPC.GetComponent<NPCInteract>().currHiddenDialouge;
            nextNPC.GetComponent<NPCInteract>().currHiddenDialouge = 
                nextNPC.GetComponent<NPCInteract>().lastHiddenDialouge + 1;
            nextNPC.transform.GetChild(0).gameObject.GetComponent<ItemDetector>().needSwitch = true;
            nextNPC.GetComponent<NPCInteract>().ifRepeatable = true;

            
            nextNPC.GetComponent<NPCEvent>().enabled = true;
            nextNPC.GetComponent<NPCInteract>().canTalk = false;
            
            nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().currDialouge =
                nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().currHiddenDialouge;

            nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().lastDialouge =
                nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().lastHiddenDialouge;
            
            nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().begIndex =
                nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().currHiddenDialouge;

            nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().currHiddenDialouge =
                nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().lastHiddenDialouge + 1;

            nextNPC.GetComponent<NPCInteract>().nextNPC.GetComponent<NPCInteract>().ifRepeatable = true;
            

        }

        

    }

    public void setIsFunComplete(bool fun)
    {
        if(fun == true){
            isFunEventComplete = fun;
            quest.Increase();
            // quest.UpdatePointer();
        }
    }

   

}
