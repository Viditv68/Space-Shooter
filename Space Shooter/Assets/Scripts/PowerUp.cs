using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private int powerupId; //0 = Tripe Shot, 1 = Speed Boost, 3 = Shields 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed *  Time.deltaTime);

        if (transform.position.y < -8.80)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with : " + other.name);
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerupId == 0)
                    player.TripleShotPowerUpOn();
                else if (powerupId == 1)
                    player.speedBoostPowerupOn();
                else if (powerupId == 2)
                    player.EnableShields();


            }
                

            
            Destroy(this.gameObject);

        }
       
    }
}
