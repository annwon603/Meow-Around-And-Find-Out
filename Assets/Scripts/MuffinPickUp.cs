
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MuffinPickUp : UdonSharpBehaviour
{
    public VRC_Pickup vrcPickup;
    public bool canPickUp;
    void Start()
    {
        vrcPickup = GetComponent<VRC_Pickup>();

    }

    private void OnPickup()
    {
        Debug.Log("I got picked up");
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
