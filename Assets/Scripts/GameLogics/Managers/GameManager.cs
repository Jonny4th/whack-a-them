using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WhackATham.Domain.Moles;

namespace WhackAThem.GameLogics.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Mole[] m_Moles;

        [SerializeField]
        private TMP_Text m_ScoreText;

        [SerializeField]
        private GameObject m_StartPanel;

        [SerializeField]
        private Button m_StartButton;

        [SerializeField]
        private float m_GameDuration = 60f;

        [SerializeField]
        private AnimationCurve m_ProgressiveIntervalCurve;

        [SerializeField]
        private AudioScriptableEvent m_MusicChannel;

        [SerializeField]
        private AudioClip m_StartMenuMusic;

        [SerializeField]
        private AudioClip m_GameplayMusic;

        private float m_Interval => m_ProgressiveIntervalCurve.Evaluate(m_GameTimer / m_GameDuration);

        private float m_GameTimer = 0f;
        private int m_Score = 0;

        private Coroutine m_GameProcess;

        private void Start()
        {
            m_MusicChannel.Play(m_StartMenuMusic);
        }

        private void OnEnable()
        {
            foreach(var mole in m_Moles)
            {
                mole.OnMoleHitEvent.AddListener(() => AddScore(1));
            }

            m_StartButton.onClick.AddListener(OnStartButtonClicked);
        }

        private void OnDisable()
        {
            foreach(var mole in m_Moles)
            {
                mole.OnMoleHitEvent.RemoveListener(() => AddScore(1));
            }

            m_StartButton.onClick.RemoveListener(OnStartButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            StartGame();
        }

        public void StartGame()
        {
            if(m_GameProcess != null)
            {
                Debug.LogWarning("Game is already in progress.");
                return;
            }

            m_Score = 0;
            m_ScoreText.text = $"Score: {m_Score}";

            m_StartPanel.gameObject.SetActive(false);
            m_GameProcess = StartCoroutine(GameProcess());
        }

        public void EndGame()
        {
            if(m_GameProcess != null)
            {
                StopCoroutine(m_GameProcess);
                m_GameProcess = null;
            }

            foreach(var mole in m_Moles)
            {
                mole.SetState(MoleState.Inactive);
            }

            m_StartPanel.gameObject.SetActive(true);
            m_MusicChannel.Play(m_StartMenuMusic);
        }

        public void AddScore(int score)
        {
            m_Score += score;
            m_ScoreText.text = $"Score: {m_Score}";
        }

        private IEnumerator GameProcess()
        {
            StartCoroutine(Timer());

            m_MusicChannel.Play(m_GameplayMusic);

            while(true)
            {
                yield return new WaitForSeconds(m_Interval);
                GetRandomMole().SetState(MoleState.Active);
            }

            Mole GetRandomMole()
            {
                var randomIndex = Random.Range(0, m_Moles.Length);
                var randomMole = m_Moles[randomIndex];

                if(randomMole.CurrentState != MoleState.Inactive)
                {
                    return GetRandomMole();
                }

                return randomMole;
            }
        }

        private IEnumerator Timer()
        {
            m_GameTimer = 0f;

            while(m_GameTimer < m_GameDuration)
            {
                yield return null;
                m_GameTimer += Time.deltaTime;
            }

            EndGame();
        }
    }
}