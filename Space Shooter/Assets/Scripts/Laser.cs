using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //if position of laser is greater than 5.5
        //destroy the laser

        if (transform.position.y >= 5.5f)
        {
            if (transform.parent != null)
                Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
        }
            

    }
}
 