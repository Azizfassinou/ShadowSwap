using UnityEngine;
using TMPro;
using System.Collections;

public class SwapUIManager : MonoBehaviour
{
    public TextMeshProUGUI swapText;

    public void ShowSwapBlockedMessage()
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine());
    }

    private IEnumerator ShowMessageRoutine()
    {
        swapText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        swapText.gameObject.SetActive(false);
    }
}
