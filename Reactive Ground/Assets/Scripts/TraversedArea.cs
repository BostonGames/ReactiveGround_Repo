using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraversedArea : MonoBehaviour
{
    public List<Transform> _traversedTile = new List<Transform>();
    public List<Transform> _previouslyTraversedTile = new List<Transform>();

    [SerializeField] GameObject traversedTilePrefab;
    [SerializeField] GameObject previouslyTraversedTilePrefab;

    private bool makeTraversedRegion = true;
    private bool makePreviouslyTraversedRegionVisible = false;

    [Tooltip("Check if you want to see if the object is on previously traversed tiles")]
    [SerializeField] bool isCheckingForPreviouslyTraversedArea = true;
    private void Awake()
    {
        _traversedTile.Add(this.transform);
    }

    private void FixedUpdate()
    {
        AddTrailSegment();
        AddTraversedTrailSegment();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TraversedArea"))
        {
            makePreviouslyTraversedRegionVisible = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TraversedArea"))
        {
            makeTraversedRegion = false;
        }
        if (other.CompareTag("PreviouslyTraversedArea"))
        {
            makePreviouslyTraversedRegionVisible = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TraversedArea"))
        {
            makeTraversedRegion = true;
        }
        if (other.CompareTag("TraversedArea"))
        {
            makePreviouslyTraversedRegionVisible = false;
        }

        //PreviouslyTraversedArea
    }

    public void AddTrailSegment()
    {
        if(makeTraversedRegion == true)
        {
            Transform trailSegment = Instantiate(this.traversedTilePrefab).transform;
            trailSegment.position = this.transform.position;
            _traversedTile.Add(trailSegment);
        }
    }

    public void AddTraversedTrailSegment()
    {
        if (makePreviouslyTraversedRegionVisible == true && isCheckingForPreviouslyTraversedArea == true)
        {
            Transform trailSegment = Instantiate(this.previouslyTraversedTilePrefab).transform;
            trailSegment.position = this.transform.position;
            _previouslyTraversedTile.Add(trailSegment);
        }
    }

}
