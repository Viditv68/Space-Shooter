using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool shieldsActive = false;

    public int lives = 3;

    [SerializeField]
    private GameObject shieldGameObject;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private GameObject laserPrefab;
    

    //fire rate is 0.25sec
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;


    [SerializeField]
    private float speed = 5.0f;
    // Start is called before the first frame update

    private UIManager uiManager;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(uiManager !=null)
        {
            uiManager.updateLives(lives);
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(spawnManager != null)
        {
            spawnManager.StartSpawnRoutines();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //if space key is pressed
        // spawn laser at player position
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {

            Shoot();


        }
        

    }
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            //spawn laser

            if(canTripleShot == true)
            {
                //for left
                Instantiate(laserPrefab, transform.position + new Vector3(-0.4f, 0.13f, 0), Quaternion.identity);
                //for Center
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                //for right
                Instantiate(laserPrefab, transform.position + new Vector3(0.4f, 0.13f, 0), Quaternion.identity);
            }

            else
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }

    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(isSpeedBoostActive == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 1.5f * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * 1.5f * verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }

        

        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);

        else if (transform.position.y < -3.4f)
            transform.position = new Vector3(transform.position.x, -3.4f, 0);



        if (transform.position.x > 9.15f)
            transform.position = new Vector3(-9.15f, transform.position.y, 0);
        else if (transform.position.x < -9.15)
            transform.position = new Vector3(9.15f, transform.position.y, 0);

    }


    public void Damage()
    {

        if(shieldsActive == true)
        {
            shieldsActive = false;
            shieldGameObject.SetActive(false);
            return;
        }
        lives--;
        uiManager.updateLives(lives);
        if (lives < 1)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.gameOver = true;
            uiManager.ShowTitleScreen();
            Destroy(this.gameObject);
        }
            
    }

    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void speedBoostPowerupOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(speedBoostDownRoutine());
    }


    public void EnableShields()
    {
        shieldsActive = true;
        shieldGameObject.SetActive(true); 
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;

    }

    public IEnumerator speedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }
}
