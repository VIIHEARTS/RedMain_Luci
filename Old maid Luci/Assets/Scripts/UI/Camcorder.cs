using TMPro;
using UnityEngine;

public class Camcorder : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI timerText;
    private float timer;

    [Header("REC")]
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float toggleInterval = 0.5f;

    private bool isVisible = true;
    private float internalTimer;


    private void Update()
    {
        internalTimer += Time.deltaTime;

        if (internalTimer >= toggleInterval)
        {
            internalTimer = 0;  
            isVisible = !isVisible;
            targetObject.SetActive(isVisible);
        }

        timer += Time.deltaTime;
        int hours = Mathf.FloorToInt(timer / 3600);
        int minutes = Mathf.FloorToInt((timer % 3600) / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);

        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}:{milliseconds:000}";
    }
}
