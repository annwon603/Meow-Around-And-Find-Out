using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirtCollider : MonoBehaviour
{
    public Mesh mesh;
    public GameObject[] dirt;
    // Start is called before the first frame update
    void Start()
    {
        //Sets up meshcollider in each dirt block
        foreach(GameObject block in dirt){
            MeshCollider mc = block.AddComponent<MeshCollider>();
            mc.sharedMesh = mesh;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
