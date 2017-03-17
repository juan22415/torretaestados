using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyball : MonoBehaviour {

    [SerializeField]
    private int bounces=5;
    private int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(count>=bounces)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter (Collision coll)
    {
        count++;
    }
}
