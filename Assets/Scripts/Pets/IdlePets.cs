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
        // Loops until enemy is defeated.
        while (true && idleDamage > 0)
        {
            // Waits set time between attacks.
            yield return new WaitForSeconds(waitTime);

            // Deals damage to enemy, displays it visually.
            StaticManagement.enemyRef.GetComponent<EnemyData>().enemyHealth -= idleDamage;
            DamageNumbers.DisplayDamageNumbers(StaticManagement.enemyRef.transform, idleDamage);

            // Check if either player or enemy health is 0 or below
            if (StaticManagement.enemyRef.GetComponent<EnemyData>().enemyHealth <= 0)
            {
                // Exit loop on enemy death.
                break;
            }
        }

        // Wait for enemy spawn + restart coroutine.
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(IdlePetBattling());
    }

    void OnEnable()
    {
        // Deals idle damage for active pets.
        StartCoroutine(IdlePetBattling());
    }
}
