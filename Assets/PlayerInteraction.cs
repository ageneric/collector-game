using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float radius = 0.5f;

    public Collider2D selectedCollider;

    // Declare hitColliders as a reusable field.
    private Collider2D[] hitColliders;

    // Set the maximum number of colliders that can be detected at once.
    private const int maxColliders = 10;

    private void Awake()
    {
        // Initialize the array just once.
        hitColliders = new Collider2D[maxColliders];
    }
     
    public void MessageOverlappingColliders(Vector3 center)
    {
        // Make the closest trigger in range in the interactableColliders list aware that we are
        // interacting with it, and vice versa for all other triggers.

        // Reuse the pre-allocated array for Physics.OverlapSphereNonAlloc.
        int numColliders = Physics2D.OverlapCircleNonAlloc(center, radius, hitColliders);

        // Get the closest collider within range
        float distance;
        float minDistance = 1000f + Mathf.Abs(radius);

        // Iterate through detected colliders (just to get the minimum, lazy coding)
        for (int i = 0; i < numColliders; i++)
        {
            Collider2D collider = hitColliders[i];
            if (collider.isTrigger)
            {
                distance = Vector2.Distance(collider.transform.position, gameObject.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    selectedCollider = collider;
                }
            }
        }

        // We only interact with the closest collider
        Debug.Log(minDistance);

        if (minDistance > 1000f)
        {
            selectedCollider = null;
        }
    }
}
