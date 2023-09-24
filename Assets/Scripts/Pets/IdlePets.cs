// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePets : MonoBehaviour
{
    // Total damage dealt every 1.5seconds by active pets.
    private int idleDamage = 0;

    // Set time between idle pet attacks.
    private float waitTime = 1.5f;

    #region Properties

    /// <summary> property <c>IdleDamage</c> allows safe access of idleDamage var, outside of current script. </summary>
    public int IdleDamage 
    {
        get { return idleDamage; }
        set { idleDamage = value; }
    }

    #endregion

    /// <summary> interface <c>IdlePetBattling</c> deals combined damage of ALL active pets to enemy every 1.5secs. </summary>
    public IEnumerator IdlePetBattling()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
