
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using UnityEngine.UI;

public class NPCDetection : UdonSharpBehaviour
{

    public bool isPlayerThere = false;

    public UdonBehaviour NPCInteraction;

    public NPCInteract npcScript;

    private GameObject dialouge;
    private GameObject theChoseOne;
    int enter = 0;
    int exit = 0;

    public void Start()
    {
        dialouge = (GameObject)NPCInteraction.GetProgramVariable("dialouge");
        theChoseOne = (GameObject)NPCInteraction.GetProgramVariable("theChoseOne");
    }

    public void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        isPlayerThere = true;
        enter++;
        Debug.Log("Player Enter " + enter + " "+ isPlayerThere);

    }

    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        isPlayerThere = false;
        dialouge.SetActive(false);
        theChoseOne.SetActive(false);
        exit++;
        Debug.Log("Player Exit" + exit+ " "+ isPlayerThere);
    }
    void Update()
    {

        dialouge = (GameObject)NPCInteraction.GetProgramVariable("dialouge");
        theChoseOne = (GameObject)NPCInteraction.GetProgramVariable("theChoseOne");
    }

   
}
