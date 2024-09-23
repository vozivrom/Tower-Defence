using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Variable;

namespace GameManage
{
    public class GameManager : MonoBehaviour
    {
        private AudioSource _effect, _music;
        [SerializeField] AudioClip _clip;
        private Animator _animSettings;
        [SerializeField] Animator _animLocation;
        [SerializeField] Toggle _musicToggle, _effectsToggle;
        private Text _coins;
        public static Animator _gameOver;

        private void Start()
        {
            _effect = GameObject.Find("Effect").GetComponent<AudioSource>();
            _music = GameObject.Find("Music").GetComponent<AudioSource>();
            _animSettings = GameObject.Find("SettingsButton").GetComponent<Animator>();
            Variables._banner = GameObject.Find("Banner").GetComponent<Image>();
            try
            {
                _coins = GameObject.Find("CoinsText").GetComponent<Text>();
                _gameOver = GameObject.Find("Game Over").GetComponent<Animator>();
            }catch{}

            Variables.coins = 100;
            
            if (!Variables.isMusicOn)
            {
                _music.mute = true;
                _musicToggle.isOn = false;
            }
            else
            {
                _music.mute = false;
                _musicToggle.isOn = true;
            }

            if (!Variables.areEffectsOn)
            {
                _effect.mute = true;
                _effectsToggle.isOn = false;
            }
            else
            {
                _effect.mute = false;
                _effectsToggle.isOn = true;
            }
        }

        private void Update()
        {
            try
            {
                _coins.text = Variables.coins.ToString();
            }catch{}
        }

        public void Banner()
        {
            if (!GameObject.Find("SettingsButton").GetComponent<Button>().interactable) SettingsClose();
            try
            {
                GameObject.Find("GunRing").SetActive(false);
            }
            catch
            {
            }

            Variables._banner.enabled = false;
        }

        public void SettingsOpen()
        {
            _animSettings.Play("SettingsOpen");
            Variables._banner.enabled = true;
        }

        public void SettingsClose()
        {
            _animSettings.Play("SettingsClose");
            Variables._banner.enabled = false;
        }

        public void StopMusic()
        {
            if (GameObject.Find("MusicToggle").GetComponent<Toggle>().isOn)
            {
                GameObject.Find("Music").GetComponent<AudioSource>().mute = false;
                Variables.isMusicOn = true;
            }
            else
            {
                GameObject.Find("Music").GetComponent<AudioSource>().mute = true;
                Variables.isMusicOn = false;
            }
        }

        public void StopEffect()
        {
            if (GameObject.Find("SoundEffectsToggle").GetComponent<Toggle>().isOn)
            {
                GameObject.Find("Effect").GetComponent<AudioSource>().mute = false;
                Variables.areEffectsOn = true;
            }
            else
            {
                GameObject.Find("Effect").GetComponent<AudioSource>().mute = true;
                Variables.areEffectsOn = false;
            }
        }

        public void PlayEffect()
        {
            _effect.PlayOneShot(_clip);
        }

        public void NextLocation()
        {
            _animLocation.Play("NextLocation");
        }

        public void PreviousLocation()
        {
            _animLocation.Play("PreviousLocation");
        }
        
        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
        
        public void Levels()
        {
            SceneManager.LoadScene("Levels");
        }

        public void Encyclopedia()
        {
            SceneManager.LoadScene("Encyclopedia");
        }

        public void Action()
        {
            SceneManager.LoadScene("Action");
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}