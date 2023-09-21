// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetInfoBox : MonoBehaviour
{
    /// <summary> method <c>SetBoxData</c> displays clicked pets info in info box. </summary>
    public void SetBoxData(PetSlotData petData)
    {
        // Data is displayed/removed depending current data.
        if (transform.GetChild(1).GetComponent<TextMeshProUGUI>().text == "Name - " + petData.petName)
        {
            // Removes displayed data.
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Name - ";
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "DPS - ";

            // Disables pet deploy button.
            transform.GetComponentInChildren<Button>(true).gameObject.SetActive(false);
        }
        else
        {
            // Sets name & damage info.
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Name - " + petData.petName;
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "DPS - " + petData.petDamage.ToString();

            // Enables pet deploy button.
            transform.GetComponentInChildren<Button>(true).gameObject.SetActive(true);

            // Checks if pet is already deployed.
            if (petData.petDeployed)
            {
                transform.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "RECALL";
            }
            else
            {
                transform.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "DEPLOY";
            }
        }       
    }

    /// <summary> method <c>DeployPet</c> sets a pet to an active slot, enables more idle damage. </summary>
    public void DeployPet()
    {
        // Retrives all info about captured pet.
        PetSlotData petToMakeActive = null;
        foreach (PetSlotData pet in StaticManagement.petSlotsRef)
        {
            if (pet.petName == transform.GetChild(1).GetComponent<TextMeshProUGUI>().text.Split("Name - ")[1])
            {
                petToMakeActive = pet;
            }
        }

        // Checks if the pet is already deployed.
        if (petToMakeActive.petDeployed)
        {
            // Returns the pet from battle.
            RecallPet(petToMakeActive);
            transform.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "DEPLOY";
            petToMakeActive.petDeployed = false;

            // Prevents uneeded execution.
            return;
        }

        // Finds the first open pet slot.
        GameObject openSlot = null;
        foreach (GameObject activeSlot in StaticManagement.activePetSlots)
        {
            // No sprite set, no active pet out.
            if (activeSlot.GetComponent<Image>().sprite == null)
            {
                openSlot = activeSlot;
                break;
            }
        }

        // Prevents full pet slot errors.
        if (openSlot == null) { return; }

        // Sets sprite & colour settings.
        openSlot.GetComponent<Image>().sprite = petToMakeActive.GetComponent<Image>().sprite;
        openSlot.GetComponent<Image>().color = petToMakeActive.GetComponent<Image>().color;

        // Pet is set to deployed.
        transform.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "RECALL";
        petToMakeActive.petDeployed = true;
    }

    /// <summary> method <c>RecallPet</c> removes the pet from the active slot, reducing DPS & allowing new pet to be deployed. </summary>
    public void RecallPet(PetSlotData activePet)
    {
        // Finds pet slot with matching sprite.
        GameObject activePetSlot = null;
        foreach (GameObject activeSlot in StaticManagement.activePetSlots)
        {
            // Finds slot with matching sprite.
            if (activeSlot.GetComponent<Image>().sprite == activePet.GetComponent<Image>().sprite)
            {
                activePetSlot = activeSlot;
                break;
            }
        }

        // Recall the pet from the active slot.
        activePetSlot.GetComponent<Image>().sprite = null;

        // Reset pet slot colour.
        Color resetColour = activePetSlot.GetComponent<Image>().color;
        resetColour.a = 0.0f;
        activePetSlot.GetComponent<Image>().color = resetColour;
    }
}