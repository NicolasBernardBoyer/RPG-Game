using UnityEngine;
using RPG.Saving;
using UnityEngine.AI;

namespace RPG.Core
{
    public class Health: MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f;

        bool alive = true;
        public bool IsAlive()
        {
            return alive;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(healthPoints);
            if (healthPoints == 0 && alive == true)
            {
                Die();
            }
        }

        private void Die()
        {
            if (!alive) return;

            alive = false;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if (healthPoints == 0)
            {
                Die();
            }
        }
    }
}