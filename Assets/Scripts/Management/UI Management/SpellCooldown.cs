// Author - Ronnie Rawlings.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellCooldown : MonoBehaviour
{
    /// <summary> method <c>StartCooldown</c> Allows a button to begin the SpellCooldowns coroutine. </summary>
    public void StartCooldown(BaseMagic spellData)
    {
        StartCoroutine(SpellCooldowns(spellData));
    }

    /// <summary> interface <c>SpellCooldowns</c> deals with the cooldown of spells, visually displays them using a slider. </summary>
    public IEnumerator SpellCooldowns(BaseMagic spellData)
    {
        // Disables use of spell.
        spellData.gameObject.GetComponentInChildren<Button>().interactable = false;

        // Finds silder component.
        Slider cooldownSlider = spellData.GetComponentInChildren<Slider>();

        // Initialize the slider values
        cooldownSlider.maxValue = spellData.SpellCooldown;
        cooldownSlider.value = spellData.SpellCooldown;

        while (cooldownSlider.value > 0)
        {
            cooldownSlider.value -= Time.deltaTime;
            yield return null; // wait for the next frame
        }

        // Re-enables use of spell.
        spellData.gameObject.GetComponentInChildren<Button>().interactable = true;
    }
}