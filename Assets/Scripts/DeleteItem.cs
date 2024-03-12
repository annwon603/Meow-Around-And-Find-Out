
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DeleteItem : UdonSharpBehaviour
{
    public GameObject itemToBeDeleted;
    
    public void Destroy()
    {
        Debug.Log("Destroy is call");
        if(itemToBeDeleted != null){
            itemToBeDeleted.SetActive(false);
            Debug.Log("Item Destroyed");
        }else{
            Debug.Log("No items to destroy");
        }

    }

}
