// Author - Ronnie Rawlings.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellCooldown : MonoBehaviour
{
    public void StartCooldown(BaseMagic spellData)
    {
        StartCoroutine(SpellCooldowns(spellData));
    }

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