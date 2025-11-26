using System;
using UnityEngine;

namespace Audio
{
    public class AudioPlayerS : MonoBehaviour, IObserver
    {
        [SerializeField] private Subject[] subjects;
        
        private AudioManager audioManager;

        private void OnEnable()
        {
            // adding this class to all the subjects

            foreach (var sub in subjects)
            {
                sub.AddObserver(this);
            }
        }

        private void OnDisable()
        {
            // adding this class to all the subjects

            foreach (var sub in subjects)
            {
                sub.RemoveObserver(this);
            }
        }

        private void Start()
        {
            audioManager = FindFirstObjectByType<AudioManager>();

            if (audioManager == null)
            {
                Debug.LogError($"Could not find AudioManager!");
            }
        }

        public void OnNotify(string eventName)
        {
            Debug.Log(eventName);
            if (eventName == "hit")
            {
                audioManager.PlayClip(0);
            }
            else if (eventName == "shoot")
            {
                audioManager.PlayClip(1);
            }
        }
    }
}
