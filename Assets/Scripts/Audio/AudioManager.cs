using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _music;
        [SerializeField] private AudioClip _gameOverSoundFx;
        [SerializeField] private AudioClip _successSoundFx;
        [SerializeField] private AudioClip _errorSoundFx;
        [SerializeField] private AudioClip _deletionSoundFx;
        [SerializeField] private AudioClip _healFx;
        [SerializeField] private AudioClip _gotPistolAmmoSoundFx;
        [SerializeField] private AudioClip _gotAssaultRifleAmmoSoundFx;
        [SerializeField] private AudioClip _pistolShootSoundFx;
        [SerializeField] private AudioClip _assaultRifleShootSoundFx;
        [SerializeField] private AudioClip _closeWindowSoundFx;
        [SerializeField] private AudioClip _openWindowSoundFx;
        [SerializeField] private AudioSource _musicAudio;
        [SerializeField] private AudioSource _soundAudio;

        private const float MAX_VOLUME = 1.0f;

        private static AudioManager _instance;
        private float _volume;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Start()
        {
            _musicAudio.volume = MAX_VOLUME;
            _soundAudio.volume = MAX_VOLUME;
            _volume = MAX_VOLUME;
            PlayAudio(AudioTrack.Music);
        }

        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AudioManager>();

                return _instance;
            }
        }

        public void PlayAudio(AudioTrack track)
        {
            switch (track)
            {
                case AudioTrack.Music:
                    AudioInnerManager(_music, true, _volume, AudioLayer.Music);
                    break;
                case AudioTrack.GameOverSoundFx:
                    AudioInnerManager(_gameOverSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.SuccessSoundFx:
                    AudioInnerManager(_successSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.ErrorSoundFx:
                    AudioInnerManager(_errorSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.DeletionSoundFx:
                    AudioInnerManager(_deletionSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.HealSoundFx:
                    AudioInnerManager(_healFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.PistolShootSoundFx:
                    AudioInnerManager(_pistolShootSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.AssaultRifleShootSoundFx:
                    AudioInnerManager(_assaultRifleShootSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.GotPistolAmmoSoundFx:
                    AudioInnerManager(_gotPistolAmmoSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.GotAssaultRifleAmmoSoundFx:
                    AudioInnerManager(_gotAssaultRifleAmmoSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.CloseWindowSoundFx:
                    AudioInnerManager(_closeWindowSoundFx, false, _volume, AudioLayer.Sound);
                    break;
                case AudioTrack.OpenWindowSoundFx:
                    AudioInnerManager(_openWindowSoundFx, false, _volume, AudioLayer.Sound);
                    break;
            }
        }

        private void AudioInnerManager(AudioClip soundToPlay, bool loop, float audioLevel, AudioLayer layer)
        {
            switch (layer)
            {
                case AudioLayer.Music:
                    _musicAudio.clip = soundToPlay;
                    _musicAudio.Play();
                    _musicAudio.loop = loop;
                    _musicAudio.volume = audioLevel;
                    break;

                case AudioLayer.Sound:
                    _soundAudio.clip = soundToPlay;
                    _soundAudio.Play();
                    _soundAudio.loop = loop;
                    _soundAudio.volume = audioLevel;
                    break;
                default:
                    Debug.LogWarning("Audio Layer Does Not Exist");
                    break;
            }
        }
    }
}