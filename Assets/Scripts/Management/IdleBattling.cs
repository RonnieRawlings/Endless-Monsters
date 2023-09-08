// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBattling : MonoBehaviour
{
    // Prevents routine from stopping outright.
    private bool idleBattling = false;

    // Time for player/enemy attacks.
    private float playerAttackTime, enemyAttackTime;

    /// <summary> interface <c>RunIdleBattle</c> has the player & enemy attack eachother forever. </summary>
    public IEnumerator RunIdleBattle()
    {
        // Initalize attack timers.
        float playerAttackTimer = 0;
        float enemyAttackTimer = 0;

        // Loops while both enemy & player are alive.
        while (true)
        {
            yield return new WaitForEndOfFrame();

            // Set attack times.
            playerAttackTime = StaticManagement.playerRef.GetComponent<PlayerData>().attackTime;
            enemyAttackTime = StaticManagement.enemyRef.GetComponent<EnemyData>().attackTime;

            // Execute player/enemy attacks.
            if (playerAttackTimer >= playerAttackTime)
            {
                // Remove health from enemy
                StaticManagement.enemyRef.GetComponent<EnemyData>().enemyHealth -= 
                    StaticManagement.playerRef.GetComponent<PlayerData>().playerBasicDamage;

                // Resets player attack timer.
                playerAttackTimer = 0;
            }
            if (enemyAttackTimer >= enemyAttackTime)
            {
                // Remove health from player
                StaticManagement.playerRef.GetComponent<PlayerData>().playerHealth -= 
                    StaticManagement.enemyRef.GetComponent<EnemyData>().enemyBasicDamage;

                // Resets enemy attack timer.
                enemyAttackTimer = 0;
            }

            // Check if either player or enemy health is 0 or below
            if (StaticManagement.playerRef.GetComponent<PlayerData>().playerHealth <= 0 || 
                    StaticManagement.enemyRef.GetComponent<EnemyData>().enemyHealth <= 0)
            {
                // Restart routine
                StopCoroutine(RunIdleBattle());
                StartCoroutine(RunIdleBattle());
                yield break;
            }

            // Increment attack timers
            playerAttackTimer += Time.deltaTime;
            enemyAttackTimer += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Player & Enemy attack continuously.
        if (!idleBattling && StaticManagement.newGameBegun) 
        {
            StartCoroutine(RunIdleBattle()); 
            idleBattling = true;
        }
    }
}
