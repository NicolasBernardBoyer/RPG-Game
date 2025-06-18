using UnityEngine;
using System;
using TMPro;
using RPG.Resources;

namespace RPG.Combat
{
    public class EnemyHealthDisplay: MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        { 
            if (fighter.GetTarget() == null && GetComponent<TMP_Text>() != null)
            {
                GetComponent<TMP_Text>().text = "N/A";
                return;
            } else if (GetComponent<TMP_Text>() != null)
            {
                Health health = fighter.GetTarget();
                GetComponent<TMP_Text>().text = String.Format("{0:0.0}%", health.GetPercentage());
            }
        }
    }
}