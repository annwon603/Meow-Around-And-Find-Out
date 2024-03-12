using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject Pillars;
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(5.0f,1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Pillars.transform.localScale = scaleChange;
    }
}
