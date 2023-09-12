// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public bool alreadyCalled = false;

    /// <summary> method <c>SetPlayerAndEnemyRefs</c> enables the player/enemy objs & sets the static refs. </summary>
    public void SetPlayerAndEnemyRefs()
    {
        // Enables player/enemy sprites
        transform.Find("Player").gameObject.SetActive(true);
        transform.Find("BaseEnemy").gameObject.SetActive(true);

        // Sets refs in static management, easier access.
        StaticManagement.playerRef = transform.Find("Player").gameObject;
        StaticManagement.enemyRef = transform.Find("BaseEnemy").gameObject;
        StaticManagement.playerOptionsRef = transform.parent.Find("PlayerUI").Find("PlayerOptions").gameObject;

        // Enable PlayerUI Panel.
        transform.parent.Find("PlayerUI").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Enables player/enemy sprites on Game Start.
        if (StaticManagement.newGameBegun && !alreadyCalled)
        {
            SetPlayerAndEnemyRefs();
            alreadyCalled = true;            
        }     
    }
}