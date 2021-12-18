using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image sessionTimeBar;
    [SerializeField] private Text dungsCount;
    [SerializeField] private Text sessionTimeCount;

    private float _spendedTime;
    private float _maxSessionTime;

    private int count = 0;

    public void UpdateSessionTime(float currentTime, float maxTime){
        _spendedTime = currentTime;
        _maxSessionTime = maxTime;
        sessionTimeCount.text = currentTime.ToString();
    }

    public void AddDungs(){
        count++;
    }

    private void Update()
    {
        InternalUpdate();
    }

    private void InternalUpdate(){

        sessionTimeBar.fillAmount = Mathf.Lerp(sessionTimeBar.fillAmount, _spendedTime/_maxSessionTime, Time.deltaTime);
        dungsCount.text = count.ToString();
        sessionTimeCount.text = math.round(_spendedTime/1000).ToString();
    }

}
