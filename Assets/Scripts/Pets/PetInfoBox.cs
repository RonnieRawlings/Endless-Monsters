// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        }
        else
        {
            // Sets name & damage info.
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Name - " + petData.petName;
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "DPS - " + petData.petDamage.ToString();
        }       
    }
}