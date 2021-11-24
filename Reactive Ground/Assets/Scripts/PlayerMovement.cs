using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Direction Player/Object is Moving")]
    [SerializeField] Vector3 _direction = new Vector3(1, 0, 0);

    //For Demo purposes
    private int score;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject pickupToSpawn;

    
    [Tooltip("Constraints pickups will spawn within")]
    [SerializeField] float maxXpos = 38f;
    [SerializeField] float minXpos = -38f;
    [SerializeField] float maxZpos = 14f;
    [SerializeField] float minZpos = -18f;

    [SerializeField] float ySpawnPos = 0f;

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = -Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            0.0f,
            Mathf.Round(this.transform.position.z) + _direction.z 
            );
    }

    //For Demo purposes
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            ScoreUp();
            Destroy(other.gameObject);
            SpawnPickup();
        }
    }
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void SpawnPickup()
    {
        Instantiate(pickupToSpawn, new Vector3(Random.Range(minXpos, maxXpos), ySpawnPos, Random.Range(minZpos, maxZpos)), Quaternion.identity);
    }
}
