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
        }       
    }

    /// <summary> method <c>DeployPet</c> sets a pet to an active slot, enables more idle damage. </summary>
    public void DeployPet()
    {

    }
}