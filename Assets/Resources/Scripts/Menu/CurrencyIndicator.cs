using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyIndicator : BaseMenu
{
    [SerializeField] TextMeshProUGUI _bodyText;
    [SerializeField] TextMeshProUGUI _bloodText;
    public void UpdateCurrencyDisplay(int bodyCount, int bloodCount)
    {
        _bodyText.text = bodyCount.ToString() + " / " + GameManager.Instance.GetMaxBodies().ToString();
        _bloodText.text = bloodCount.ToString() + " / " + GameManager.Instance.GetMaxBlood().ToString();
    }
}
