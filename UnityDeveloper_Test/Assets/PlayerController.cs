using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject hologramPrefab;
    public Rigidbody playerRigidbody;
    private GameObject hologramInstance;
    private float gravityStrength = 9.8f;
    private LayerMask walkableSurfaceLayer;
    public Quaternion hologramAdjustmentRotation = Quaternion.identity;
    public float heightAboveHead = 2.0f;

    void Start()
    {
        walkableSurfaceLayer = LayerMask.GetMask("WalkableSurface");  // Assign the layer mask
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpawnHologram(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SpawnHologram(-Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpawnHologram(-Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SpawnHologram(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeGravity();
        }
    }

    void ChangeGravity()
    {
        if (hologramInstance != null)
        {
            Vector3 direction = hologramInstance.transform.position - transform.position;
            direction.Normalize();

            playerRigidbody.useGravity = false;
            playerRigidbody.AddForce(direction * gravityStrength);
            Debug.Log("Inside ChangeGravity method");

            // Rotate the player to match the hologram's rotation
            transform.rotation = hologramInstance.transform.rotation;

          
        }
    }




    void SpawnHologram(Vector3 offset)
    {
        Destroy(hologramInstance); // Destroy previous hologram

        // Calculate the position where the hologram should be instantiated
        Vector3 spawnPosition = transform.position + Vector3.up * heightAboveHead;

        // Calculate desired rotation based on offset direction
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, -offset); // Adjusted rotation

        // Apply adjustment rotation
        rotation *= hologramAdjustmentRotation;

        // Instantiate hologram with adjusted offset and rotation
        hologramInstance = Instantiate(hologramPrefab, spawnPosition, rotation);
    }




}
