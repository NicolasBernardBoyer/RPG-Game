using System.Collections;
using UnityEngine;

namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";

        private IEnumerator Start()
        {
            yield return GetComponent<SavingSystemT>().LoadLastScene(defaultSaveFile);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
        }

        public void Load()
        {
            GetComponent<SavingSystemT>().Load(defaultSaveFile);
        }

        public void Save()
        {
            GetComponent<SavingSystemT>().Save(defaultSaveFile);
        }
    }
}
