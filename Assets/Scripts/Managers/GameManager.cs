using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Mole[] m_Moles;

    [SerializeField]
    Button m_StartButton;

    [SerializeField]
    private float m_GameDuration = 60f;

    [SerializeField]
    private float m_Interval = 1f;

    private float m_GameTimer = 0f;
    private int m_Score = 0;

    private Coroutine m_GameProcess;

    private void OnEnable()
    {
        foreach(var mole in m_Moles)
        {
            mole.OnMoleHitEvent.AddListener(() => m_Score++);
        }

        m_StartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnDisable()
    {
        foreach(var mole in m_Moles)
        {
            mole.OnMoleHitEvent.RemoveListener(() => m_Score++);
        }

        m_StartButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void Update()
    {
        if(m_GameTimer >= m_GameDuration)
        {
            EndGame();
        }
        else
        {
            m_GameTimer += Time.deltaTime;
        }
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
        m_GameTimer = 0;

        m_StartButton.gameObject.SetActive(false);
        m_GameProcess = StartCoroutine(GameProcess());
    }

    public void EndGame()
    {
        if(m_GameProcess != null)
        {
            StopCoroutine(m_GameProcess);
            m_GameProcess = null;
        }

        m_StartButton.gameObject.SetActive(true);
    }

    public void AddScore(int score)
    {
        m_Score += score;
    }

    private IEnumerator GameProcess()
    {
        while(true)
        {
            GetRandomMole().SetState(new ActiveState());
            yield return new WaitForSeconds(m_Interval);
        }

        Mole GetRandomMole()
        {
            var randomIndex = Random.Range(0, m_Moles.Length);
            var randomMole = m_Moles[randomIndex];

            if(randomMole.CurrentState == MoleState.Active)
            {
                return GetRandomMole();
            }

            return randomMole;
        }
    }
}
