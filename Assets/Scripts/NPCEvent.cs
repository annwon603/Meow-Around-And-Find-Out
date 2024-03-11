
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NPCEvent : UdonSharpBehaviour
{
    //Reference to currentNPC can talk
    public GameObject currNPC;
    //Referencing to event
    public UdonBehaviour findItem;
    public ItemPickUp itemfinder; 
    bool ready;

    void Start()
    {
        ready = currNPC.GetComponent<NPCInteract>().canPickItem;

    }

    void Update()
    {
        ready = currNPC.GetComponent<NPCInteract>().canPickItem;
        itemfinder.setPickUp(ready);

    }
}
