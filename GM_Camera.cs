using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Camera: MonoBehaviour {

    Transform target;               // Thing for camera to follow
    public Transform camBoundMin;   // Lowest and leftest value camera can move
    public Transform camBoundMax;   // Highest and rightest value camera can move

    float xMin, xMax, yMin, yMax;
    
    // Use this for initialization
    void Start () {

        // Find 'Player' in Scene
        // - Player must be tagged as 'Player' to be found
        GameObject go = GameObject.FindWithTag("Player");
        if(!go)
        {
            Debug.Log("Player not found.");
            return;
        }

        target = go.GetComponent<Transform>();

        // Uses GameObjects to set the min and max values for camera movement
        // - Update if 'Player' can move in different ranges of level
        xMin = camBoundMin.position.x;
        yMin = camBoundMin.position.y;

        xMax = camBoundMax.position.x;
        yMax = camBoundMax.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        if(target)
        {
            // Change camera position to follow player, if player is in range
            // - Mathf.Clamp, keeps first argument within range of second(min) and third(max)
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, xMin, xMax),
                Mathf.Clamp(target.position.y, yMin, yMax),
                transform.position.z);
        }
		
	}
}
