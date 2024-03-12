
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemDetector : UdonSharpBehaviour
{   

    public GameObject item;

    public GameObject ifSecondItem;

    public bool needSwitch = false;

    //NPC's Quest
    public GameObject NPC;

    public GameObject ifSecondNPC;

    public GameObject currNPC;
    void OnTriggerEnter(Collider other)
    {
        if(needSwitch == false){

            if(other.gameObject == item){
                NPC.GetComponent<NPCInteract>().setIsFunComplete(true);
                currNPC.GetComponent<NPCInteract>().canTalk = true;
                Debug.Log("I detect: " + item);
            }
        }else{
            if(other.gameObject == ifSecondItem){
                ifSecondNPC.GetComponent<NPCInteract>().setIsFunComplete(true);
                currNPC.GetComponent<NPCInteract>().canTalk = true;
                Debug.Log("I detect: " + ifSecondItem);
            }
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        if(needSwitch == false){
            if(other.gameObject == item){
                NPC.GetComponent<NPCInteract>().setIsFunComplete(false);
            }
        }else{
            if(other.gameObject == ifSecondItem){
                ifSecondNPC.GetComponent<NPCInteract>().setIsFunComplete(false);
            }
        }

    }
}
