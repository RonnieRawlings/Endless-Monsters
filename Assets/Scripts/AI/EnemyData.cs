// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    // Multiple call prevention.
    public bool changeCalled;

    // Basic battling variables.
    public float enemyHealth, enemyBasicDamage, MAX_ENEMY_HP;

    // Reward drops
    public int manaDrop;

    // Time between attacks.
    public float attackTime = 4f;

    private void OnEnable()
    {
        if (gameObject.name == "BaseEnemy" && !changeCalled)
        {
            StartCoroutine(StaticManagement.ChangeEnemies(0.01f));
            changeCalled = true;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        // If dead, spawn new enemy.
        if (enemyHealth <= 0 && !changeCalled) 
        { 
            StartCoroutine(StaticManagement.ChangeEnemies(0.5f));
            changeCalled = true;
        }
    }
}
