
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BakerEvent : UdonSharpBehaviour
{
    //Referecing to the baker's canTalk 
    public UdonBehaviour baker;
    public NPCInteract bakerscript; 

    //Referencing to the fun event 
    public UdonBehaviour muffin;
    public MuffinPickUp muffinpickMe;

    bool ready;
    void Start()
    {
        ready = (bool)baker.GetProgramVariable("canTalk");

    }

    void Update()
    {
        ready = (bool)baker.GetProgramVariable("canTalk");
        muffinpickMe.setPickUp(ready);
        
    }




}
