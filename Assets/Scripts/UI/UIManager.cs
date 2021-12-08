using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image sessionTimeBar;
    [SerializeField] private Text dungsCount;

    private float spendedTime;
    private float maxSessionTime;

    private int count = 0;

    public void UpdateSessionTime(float currentTime, float maxTime){
        spendedTime = currentTime;
        maxSessionTime = maxTime;
    }

    public void AddDungs(){
        count++;
    }

    private void Update()
    {
        InternalUpdate();
    }

    private void InternalUpdate(){

        sessionTimeBar.fillAmount = Mathf.Lerp(sessionTimeBar.fillAmount, spendedTime/maxSessionTime, Time.deltaTime);
        dungsCount.text = count.ToString();
    }

}
