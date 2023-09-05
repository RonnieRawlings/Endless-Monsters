// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    /// <summary> method <c>UpdatePlayerHealth</c> Changes the visual health indicator, based on remaining player HP. </summary>
    public void UpdatePlayerHealth()
    {
        // Gets access to current playerHp + HP visual ref.
        PlayerData playerHP = StaticManagement.playerRef.GetComponent<PlayerData>();
        GameObject playerHpVisual = transform.Find("PlayerHealth").gameObject;

        // Sets text visual to current HP.
        playerHpVisual.transform.GetComponentInChildren<TextMeshProUGUI>().text = playerHP.playerHealth.ToString() + 
            " / " + playerHP.MAX_PLAYER_HP;

        // Changes slider HP value.
        GameObject hpSlider = playerHpVisual.transform.Find("Slider").gameObject;
        hpSlider.GetComponent<Slider>().maxValue = playerHP.MAX_PLAYER_HP;
        hpSlider.GetComponent<Slider>().value = playerHP.playerHealth;
    }

    /// <summary> method <c>UpdateEnemyHealth</c> Changes the visual health indicator, based on remaining enemy HP. </summary>
    public void UpdateEnemyHealth()
    {
        // Gets access to current playerHp + HP visual ref.
        EnemyData enemyHP = StaticManagement.enemyRef.GetComponent<EnemyData>();
        GameObject enemyHpVisual = transform.Find("EnemyHealth").gameObject;

        // Sets text visual to current HP.
        enemyHpVisual.transform.GetComponentInChildren<TextMeshProUGUI>().text = enemyHP.enemyHealth.ToString() +
            " / " + enemyHP.MAX_ENEMY_HP;

        // Changes slider HP value.
        GameObject hpSlider = enemyHpVisual.transform.Find("Slider").gameObject;
        hpSlider.GetComponent<Slider>().maxValue = enemyHP.MAX_ENEMY_HP;
        hpSlider.GetComponent<Slider>().value = enemyHP.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
        UpdateEnemyHealth();
    }
}
