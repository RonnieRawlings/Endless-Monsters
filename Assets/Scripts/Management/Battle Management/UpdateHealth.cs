// Author - Ronnie Rawlings.

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    private float lastPlayerHealth;
    private float lastEnemyHealth;

    /// <summary> method <c>UpdatePlayerHealth</c> Changes the visual health indicator, based on remaining player HP. </summary>
    public void UpdatePlayerHealth()
    {
        // Gets access to current playerHp
        PlayerData playerHP = StaticManagement.playerRef.GetComponent<PlayerData>();

        // If player health hasn't changed, return
        if (playerHP.playerHealth == lastPlayerHealth) return;
        lastPlayerHealth = playerHP.playerHealth;

        // Works out the amount of damage dealt.
        int damageNum = (int)playerHP.playerHealth - (int)lastPlayerHealth;

        // Updates last enemy HP
        lastPlayerHealth = playerHP.playerHealth;

        // HP visual ref.
        GameObject playerHpVisual = transform.Find("PlayerHealth").gameObject;

        // Prevents negative HP from being displayed.
        float currentHp = 0;
        if (playerHP.playerHealth > 0) { currentHp = playerHP.playerHealth; }

        // Sets text visual to current HP.
        playerHpVisual.transform.GetComponentInChildren<TextMeshProUGUI>().text = currentHp.ToString() + 
            " / " + playerHP.MAX_PLAYER_HP;

        // Changes slider HP value.
        GameObject hpSlider = playerHpVisual.transform.Find("Slider").gameObject;
        hpSlider.GetComponent<Slider>().maxValue = playerHP.MAX_PLAYER_HP;
        hpSlider.GetComponent<Slider>().value = playerHP.playerHealth;
    }

    /// <summary> method <c>UpdateEnemyHealth</c> Changes the visual health indicator, based on remaining enemy HP. </summary>
    public void UpdateEnemyHealth()
    {
        // Gets access to current enemyHp
        EnemyData enemyHP = StaticManagement.enemyRef.GetComponent<EnemyData>();

        // If enemy health hasn't changed, return
        if (enemyHP.enemyHealth == lastEnemyHealth) return;
        lastEnemyHealth = enemyHP.enemyHealth;

        // HP visual ref.
        GameObject enemyHpVisual = transform.Find("EnemyHealth").gameObject;

        // Prevents negative HP from being displayed.
        float currentHp = 0;
        if (enemyHP.enemyHealth > 0) { currentHp = enemyHP.enemyHealth; }

        // Sets text visual to current HP.
        enemyHpVisual.transform.GetComponentInChildren<TextMeshProUGUI>().text = currentHp.ToString() +
            " / " + enemyHP.MAX_ENEMY_HP;

        // Changes slider HP value.
        GameObject hpSlider = enemyHpVisual.transform.Find("Slider").gameObject;
        Slider sliderComponent = hpSlider.GetComponent<Slider>();
        sliderComponent.maxValue = enemyHP.MAX_ENEMY_HP;

        // Ensure that enemyHealth is not less than 0
        sliderComponent.value = Mathf.Max(enemyHP.enemyHealth, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
        UpdateEnemyHealth();
    }
}