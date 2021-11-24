using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMaker : MonoBehaviour
{
    public List<Transform> _segments = new List<Transform>();
    [SerializeField] GameObject segmentPrefab;


    private void Awake()
    {
        _segments.Add(this.transform);
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            if(_segments[i] != null)
            {
                _segments[i].position = _segments[i - 1].position;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            AddSegment();
        }
    }

    public void AddSegment()
    {
        Transform trailSegment = Instantiate(this.segmentPrefab).transform;
        trailSegment.position = _segments[_segments.Count - 1].position;
        _segments.Add(trailSegment);
    }


}
