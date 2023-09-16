// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDamageNums : MonoBehaviour
{
    // Animation duration + final position.
    public float duration = 1.0f;
    public Vector3 offset = new Vector3(-130, 80, 0);

    // Objs start position & exact time before routine begins.
    private Vector3 startPosition;
    private float startTime;

    /// <summary> interface <c>AnimateDamageNumObject</c> executes a simple animation for the damage nums before destorying them. </summary>
    public IEnumerator AnimateDamageNumObject()
    {
        // Animates the obj.
        while (Time.time - startTime < duration)
        {
            // Animation elapsed time.
            float t = (Time.time - startTime) / duration;

            // Moves obj, t * t = quadratic curve.
            transform.position = Vector3.Lerp(startPosition, startPosition + offset, t * t);

            // Satisfies return req, waits no time.
            yield return null;
        }

        // Removes damage num from scene.
        Destroy(this.gameObject);
    }

    // Called once on script initlization.
    private void OnEnable()
    {
        // Set start pos + time.
        startPosition = transform.position;
        startTime = Time.time;

        // Start the animation.
        StartCoroutine(AnimateDamageNumObject());
    }
}