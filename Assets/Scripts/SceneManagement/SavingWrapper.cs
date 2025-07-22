using System;
using UnityEngine;
using RPG.Saving;
using System.Collections;
using GameDevTV.Saving;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";
        [SerializeField] float fadeInTime = 0.2f;


        private void Awake()
        {
            StartCoroutine(LoadLastScene());    
        }

        private IEnumerator LoadLastScene()
        {
            yield return GetComponent<JsonSavingSystem>().LoadLastScene(defaultSaveFile);
            Fader fader = FindFirstObjectByType<Fader>();
            fader.FadeOutImmediate();
            yield return fader.FadeIn(fadeInTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        public void Save()
        {
            GetComponent<JsonSavingSystem>().Save(defaultSaveFile);
        }

        public void Load()
        {
            GetComponent<JsonSavingSystem>().Load(defaultSaveFile);
        }

        public void Delete()
        {
            GetComponent<JsonSavingSystem>().Delete(defaultSaveFile);
        }
    }
}
