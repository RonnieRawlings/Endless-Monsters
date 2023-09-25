// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    // Text ref for current stage.
    private TextMeshProUGUI currentStageText;

    // Last reference to the active enemy.
    private GameObject currentEnemy;

    /// <summary> interface <c>BeginningWait</c> waits out starting enemy, begings UpdateStage after. </summary>
    public IEnumerator BeginningWait()
    {
        yield return new WaitForSeconds(0.1f);

        // Sets starting enemy ref, begins routine.
        currentEnemy = StaticManagement.enemyRef;
        StartCoroutine(UpdateStage());
    }

    /// <summary> interface <c>UpdateStage</c> keeps track of the current stage, updates on enemy death. </summary>
    public IEnumerator UpdateStage()
    {       
        // Checks if enemy has been defeated.
        if (currentEnemy != StaticManagement.enemyRef)
        {
            // Updates stage text by 1.
            string[] splitText = currentStageText.text.Split("STAGE ");
            currentStageText.text = "STAGE " + (int.Parse(splitText[1]) + 1).ToString();

            // Updates enemy ref.
            currentEnemy = StaticManagement.enemyRef;
        }

        // Statisfys return req, waits no time.
        yield return null;

        // Re-calls itself indefinitly.
        StartCoroutine(UpdateStage());
    }

    // Called once on script initlization.
    void OnEnable()
    {
        // Sets current stage ref.
        currentStageText = transform.Find("StageInfo").GetComponentInChildren<TextMeshProUGUI>();

        // Begins routine, checks if stage is complete.
        StartCoroutine(BeginningWait());
    }
}