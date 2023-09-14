// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class DamageNumbers
{
    /// <summary> static method <c>DisplayDamageNumbers</c> spawns a textmesh which displays exact damage dealt. </summary>
    public static void DisplayDamageNumbers(Transform parentRef, int damageNum)
    {
        // Create new obj + find canvas.
        GameObject textObject = new GameObject("DamageNumbers");

        // Set canvas as parent/positon.
        textObject.transform.SetParent(parentRef);
        textObject.transform.position = textObject.transform.parent.position;

        // Add desired components to textObj.
        TextMeshProUGUI damageNumber = textObject.AddComponent<TextMeshProUGUI>();
        textObject.AddComponent<MoveDamageNums>();

        // Set damage text.
        damageNumber.text = "-" + damageNum.ToString();
    }
}