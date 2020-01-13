using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private float speed = 2.0f;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        float randomX = Random.Range(-8.80f, 8.80f);

        if (transform.position.y < -5.3f)
            transform.position = new Vector3(randomX, 5.3f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            if (other.transform.parent != null)
                Destroy(other.transform.parent.gameObject);
            Destroy(other.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            uiManager.updateScore(); 
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
                player.Damage();


            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
  
    }
}
