// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveDamageNums : MonoBehaviour
{
    // Animation duration + final position.
    public float duration = 0.75f;
    public Vector3 finalPos = new Vector3(-50, 70, 0);

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
            transform.position = Vector3.Lerp(startPosition, startPosition + finalPos, t * t);

            // Fade out over time.
            Color color = GetComponent<TextMeshProUGUI>().color;
            color.a = Mathf.Lerp(1, 0, t);
            GetComponent<TextMeshProUGUI>().color = color;

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