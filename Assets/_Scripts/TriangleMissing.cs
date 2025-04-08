using UnityEngine;
using TMPro;

public class TriangleMissing : MonoBehaviour
{
    public TextMeshProUGUI TriangleMissingText;
    public static TriangleMissing Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        TriangleMissingText.text = ": X" + GameControler.GetRemaining().ToString();
    }
}
