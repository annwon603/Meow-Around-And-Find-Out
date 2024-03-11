
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OvenDetect : UdonSharpBehaviour
{
    public GameObject muffin;

    public UdonBehaviour baker;
    public NPCInteract bakerscript; 


    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == muffin){
            Debug.Log("Muffin Left");
            bakerscript.setIsFunComplete(true);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == muffin){
            Debug.Log("Muffin In");
            bakerscript.setIsFunComplete(false);
        }
    }


}
