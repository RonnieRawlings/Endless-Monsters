// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseMagic : MonoBehaviour
{
    // Basic magic values.
    [SerializeField] private int magicDamage, magicCost;

    /// <summary> method <c>UseSpell</c> allows player to attack with the clicked spell, applies set damage at mana cost. </summary>
    public void UseSpell()
    {
        // Find & split current mana pool.
        TextMeshProUGUI manaPoolText = StaticManagement.playerOptionsRef.transform.Find("ManaPool").GetComponentInChildren<TextMeshProUGUI>();
        int currentMana = int.Parse(manaPoolText.text.Split("Mana")[0]);

        // Check for correct mana remaining.
        if (currentMana < magicCost) { return; }

        // Apply damage.
        StaticManagement.enemyRef.GetComponent<EnemyData>().enemyHealth -= magicDamage;

        // Remove mana.      
        manaPoolText.text = (currentMana - magicCost).ToString() + " Mana";
    }
}
