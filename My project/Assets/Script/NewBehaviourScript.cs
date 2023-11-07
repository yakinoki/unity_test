using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = player.transform.position.z;
            if (x < leftLimit)
            {
                leftLimit = x;
            }
            else if (x > rightLimit)
            {
                rightLimit = x;
            }
            if (y < bottomLimit)
            {
                bottomLimit = y;
            }
            else if(y > topLimit)
            {
                topLimit = y;
            }
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
    }
}
