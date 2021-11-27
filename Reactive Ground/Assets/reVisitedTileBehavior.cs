using UnityEngine;

public class reVisitedTileBehavior : MonoBehaviour
{
    [SerializeField] GameObject reVisitedTile;
    [SerializeField] Color reVisitedColor = new Color(1, 1, 1, 1);

    private void Awake()
    {
        reVisitedTile.GetComponent<Renderer>().material.color = reVisitedColor;
    }

    //TODO: possibly change so that only the Player tag is the trigger (?)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reVisitedTile.SetActive(true);
        }
    }
}
