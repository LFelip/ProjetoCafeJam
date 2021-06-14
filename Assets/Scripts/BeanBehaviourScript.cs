using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBehaviourScript : MonoBehaviour
{
    private Vector2 screenBounds;



    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
 

        transform.position = new Vector3(Random.RandomRange(-screenBounds.x, screenBounds.x), 
            Random.RandomRange(-screenBounds.y, screenBounds.y), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
