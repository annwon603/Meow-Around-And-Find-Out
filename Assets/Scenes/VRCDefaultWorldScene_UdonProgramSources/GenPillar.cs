
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GenPillar : UdonSharpBehaviour
{
    public GameObject[] pillars;
    private Vector3 scaleChange = new Vector3(5.0f,1.0f,1.0f);

    private Vector3 positionChange = new Vector3(0.0f, 0.0f, 3.0f);

    private Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPos = pillars[0].transform.position;
        for( int i = 1 ; i < pillars.Length ; i++){
            currentPos+=positionChange;
            pillars[i].transform.position = currentPos;
            pillars[i].transform.localScale = scaleChange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
