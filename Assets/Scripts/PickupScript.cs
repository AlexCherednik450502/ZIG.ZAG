using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    private static float rotationSpeed = 30;
    private static Vector3 rotationAxis = new Vector3(0,1,0);
    	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            float rotateBy = rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAxis, rotateBy);
        }
        
	}
}
