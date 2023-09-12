// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{
    /// <summary> method <c>StartCooldown</c> Starts the coroutine used to prevent repeated spell uses. </summary>
    public void StartCooldown(BaseMagic spellData)
    {
        StartCoroutine(SpellCooldowns(spellData));
    }

    /// <summary> interface <c>SpellCooldowns</c> Disables specific spell until cooldown has passed, prevents repeated used. </summary>
    public IEnumerator SpellCooldowns(BaseMagic spellData)
    {
        // Disables use of spell.
        spellData.gameObject.GetComponentInChildren<Button>().interactable = false;

        // Spell cooldown.
        yield return new WaitForSeconds(spellData.SpellCooldown);

        // Re-enables use of spell.
        spellData.gameObject.GetComponentInChildren<Button>().interactable = true;
    }
}
