using UnityEngine;
using System;
using TMPro;
using RPG.Resources;

namespace RPG.Combat
{
    public class EnemyHealthDisplay: MonoBehaviour
    {
        Fighter fighter;
        [SerializeField] TMP_Text healthText = null;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                healthText.text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();
            healthText.text = String.Format("{0:0.0}%", health.GetPercentage());
        }
    }
}