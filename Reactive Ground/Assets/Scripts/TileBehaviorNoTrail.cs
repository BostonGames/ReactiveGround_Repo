using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviorNoTrail : MonoBehaviour
{
    [SerializeField] GameObject visitedTile, visitedCollider;
    [SerializeField] Color visitedColor = new Color(1, 1, 1, 1);

    [SerializeField] Color initialColor;

    private void Awake()
    {
        this.GetComponent<Renderer>().material.color = initialColor;
        visitedTile.GetComponent<Renderer>().material.color = visitedColor;
    }

    //TODO: possibly change so that only the Player tag is the trigger (?)
    private void OnTriggerEnter(Collider other)
    {
        visitedTile.SetActive(true);

        StartCoroutine(AddVisitedColliderAfterXSeconds(0.2f));

    }


    IEnumerator AddVisitedColliderAfterXSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        visitedCollider.SetActive(true);
    }
}
