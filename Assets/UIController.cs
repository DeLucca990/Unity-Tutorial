using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text timerText;
    public Text collectedText;

    public void UpdateTimer(float time)
    {
        timerText.text = "Tempo Restante: " + time.ToString("F1") + "s";
    }

    public void UpdateCollected(int collected, int total)
    {
        collectedText.text = $"Itens Coletados: {collected}/{total}";
    }
}
