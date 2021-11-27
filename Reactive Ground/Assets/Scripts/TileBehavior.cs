using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [SerializeField] GameObject visitedTile, visitedCollider;
    [SerializeField] Color activatedColor = new Color(1, 1, 1, 1);
    [SerializeField] Color visitedColor = new Color(1, 1, 1, 1);

    [SerializeField] Color initialColor;

    [SerializeField] float trailFadeTime = 0.5f;

    private void Awake()
    {
        initialColor = visitedTile.GetComponent<Renderer>().material.color;
    }

    //TODO: possibly change so that only the Player tag is the trigger (?)
    private void OnTriggerEnter(Collider other)
    {
        visitedTile.SetActive(true);

        if (visitedTile.GetComponent<Renderer>().material.color == initialColor)
        {
            visitedTile.GetComponent<Renderer>().material.color = activatedColor;
            StartCoroutine(ColorLerpFunction(trailFadeTime));
        }
        else
        {
            StopAllCoroutines();
            visitedTile.GetComponent<Renderer>().material.color = activatedColor;
            StartCoroutine(ColorLerpFunction(trailFadeTime));
        }

        StartCoroutine(AddVisitedColliderAfterXSeconds(0.2f));

    }

    private void OnTriggerExit(Collider other)
    {
        //for if the player is able to stand still 
        // and you want the tile to be lit up the whole time they are standing: 
        // StartCoroutine(ColorLerpFunction(fadeTime));
    }

    IEnumerator ColorLerpFunction(float fadeDuration)
    {
        float time = 0;
        Material materialToChange = visitedTile.GetComponent<Renderer>().material;


        while (time < fadeDuration)
        {
            materialToChange.color = Color.Lerp(activatedColor, visitedColor, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator AddVisitedColliderAfterXSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        visitedCollider.SetActive(true);
    }
}
