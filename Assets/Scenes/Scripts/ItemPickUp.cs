
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemPickUp : UdonSharpBehaviour
{
    public VRC_Pickup vrcPickup;

    public bool canPickUp;
    void Start()
    {
        vrcPickup = GetComponent<VRC_Pickup>();
    }

    void Update()
    {
        vrcPickup.pickupable = canPickUp;
    }

    public void setPickUp(bool pickME)
    {
        canPickUp = pickME;
    }
}
