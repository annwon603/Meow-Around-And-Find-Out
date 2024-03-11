
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemDetector : UdonSharpBehaviour
{   
    public GameObject item;

    //NPC's Quest
    public GameObject NPC;

    public GameObject currNPC;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == item){
            NPC.GetComponent<NPCInteract>().setIsFunComplete(true);
            currNPC.GetComponent<NPCInteract>().canTalk = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == item){
            NPC.GetComponent<NPCInteract>().setIsFunComplete(false);
        }
    }
}
