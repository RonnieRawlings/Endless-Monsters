// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDamageNums : MonoBehaviour
{
    /// <summary> interface <c>AnimateDamageNumObject</c> executes a simple animation for the damage nums before destorying them. </summary>
    public IEnumerator AnimateDamageNumObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    // Called once on script initlization.
    private void OnEnable()
    {
        StartCoroutine(AnimateDamageNumObject());
    }
}
