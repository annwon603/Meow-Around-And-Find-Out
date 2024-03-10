
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

    //Accessing to chatbox
    public GameObject dialouge;

    //Accessing to index to list of dialouge
    public int Type; 

    public GameObject[] listOfDialouges;

    //The chosen dialouge to put into chat box
    GameObject theChoseOne;
    private bool canClick;

    bool hasClick = false;
    void Start()
    {
        dialouge.SetActive(false);
        theChoseOne = listOfDialouges[Type];

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
        if(hasClick == false && canClick == true){
            Debug.Log("You're talking to NPC");
            dialouge.SetActive(true);
            theChoseOne.SetActive(true);
            hasClick = true;
        }else{
            dialouge.SetActive(false);
            theChoseOne.SetActive(false);
            hasClick = false;
        }

    }

    // public void SetOff()
    // {
    //     dialouge.SetActive(false);
    //     theChoseOne.SetActive(false);
    //     hasClick = false;

    // }
}
