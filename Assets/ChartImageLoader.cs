using UnityEngine;
using System.Collections;

public class LCDChartDisplay : MonoBehaviour
{
    public Renderer lcdRenderer;
    private Texture2D chartTexture;

    private readonly string[] imageUrls = new string[]
    {
        "https://finviz.com/chart.ashx?t=AAPL",
        "https://finviz.com/chart.ashx?t=TSLA",
        "https://finviz.com/chart.ashx?t=MSFT",
        "https://finviz.com/chart.ashx?t=GOOGL",
        "https://finviz.com/chart.ashx?t=AMZN"
    };

    void Start()
    {
        chartTexture = new Texture2D(2, 2);
        lcdRenderer.material.mainTexture = chartTexture;

        StartCoroutine(UpdateChart());
    }

    IEnumerator UpdateChart()
    {
        while (true)
        {
            // 🔀 Rastgele grafik seç
            string randomUrl = imageUrls[Random.Range(0, imageUrls.Length)];

            using (WWW www = new WWW(randomUrl))
            {
                yield return www;
                if (string.IsNullOrEmpty(www.error))
                {
                    www.LoadImageIntoTexture(chartTexture);
                    lcdRenderer.material.mainTexture = chartTexture;
                }
                else
                {
                    Debug.LogError("Grafik yüklenemedi: " + www.error);
                }
            }

            yield return new WaitForSeconds(5);
        }
    }
}
