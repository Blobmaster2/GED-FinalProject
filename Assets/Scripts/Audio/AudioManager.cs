using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip[] audioClips = {};
        [SerializeField] AudioSource audioSource;

        private int audioClipsLength = 0;
    
        private static AudioManager Instance { get; set; }
    
        private void Awake()
        {
            // Check if an instance already exists
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Prevent duplicates
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it between scenes
        }

        private void Start()
        {
            audioClipsLength = audioClips.Length;
        }

        private void Update()
        {
            transform.position = GameManager.PlayerPosition;
        }

        public void PlayClip(int clipIndex)
        {
            if (audioClipsLength > clipIndex)
            {
                Debug.Log("Playing clip " + clipIndex);
                audioSource.PlayOneShot(audioClips[clipIndex]);
            }
            else
            {
                Debug.Log("can't play clip " + clipIndex + ". max length " + audioClipsLength);
            }
        }
    }
}
