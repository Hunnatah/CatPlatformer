using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FallingPlatform : MonoBehaviour
{

    private bool isOnPlatform;
    public bool susPlatform;
    public bool hasSpawned = false;
    private float timer;
    private Rigidbody rb;
    private Vector3 orgPosition;
    private Quaternion orgRotation;

    
    public GameObject platformPrefab; 
 
    [SerializeField] private float fallDelay;
    private float fallSpeed = 5f;
    public Material redMaterial;
    //public GameObject susColour;//probuilder prefab

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //lock the platform v3 position 
        rb.isKinematic = true;

        //player not on platform
        isOnPlatform = false;

     
        //susColour.SetActive(false);

        orgPosition = platformPrefab.transform.position;
        orgRotation = platformPrefab.transform.rotation;
    }



    private void Update()
    {
        if (isOnPlatform && susPlatform == true)
        {

            //check if the timer(0 second) + in game second is bigger than fallDelay time
            timer = Time.time;
            if (timer >= fallDelay)
            {
                //susColour.SetActive(true);
                gameObject.GetComponent<Renderer>().material = redMaterial; 
                StartCoroutine(DelayedFalling());
                
            }
        }

        if (transform.position.y < orgPosition.y - 100f)
        {
            
            Destroy(gameObject);
            
        }
    }
   
    private IEnumerator DelayedFalling()
    {
        yield return new WaitForSeconds(2f);

        isFalling(); 
    }

    private void isFalling()
    {
        //unlock the position of the platform so it can be movable
        rb.isKinematic = false;
        //add force to downward * fallspeed
        rb.AddForce(Vector3.down * fallSpeed * Time.deltaTime, ForceMode.VelocityChange);
        //destory the gameobject after falling for 2 second + the delay time
        //Destroy(gameObject, 2f);
       

        if (!hasSpawned )
        {
            hasSpawned = true;
            StartCoroutine(SpawnPlatform());
        }
    }

   public IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(3f);
        hasSpawned = false;
        Instantiate(platformPrefab, orgPosition, orgRotation) ;
      
                

    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if gameoject tagged "player" hit the collision
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnPlatform = true;
        }
    }

    

   
}
