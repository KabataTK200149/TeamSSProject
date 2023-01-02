using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPointBase : MonoBehaviour
{
    [SerializeField] Text skillText;
    [SerializeField] Text HPText;
    [SerializeField] Text STRText;
    [SerializeField] Text VITText;
    [SerializeField] Text AGIText;
    [SerializeField] Text INTText;
    [SerializeField] Text HPcounterText;
    [SerializeField] Text STRcounterText;
    [SerializeField] Text VITcounterText;
    [SerializeField] Text AGIcounterText;
    [SerializeField] Text INTcounterText;

    [SerializeField] GameObject HPcounterObject;
    [SerializeField] GameObject STRcounterObject;
    [SerializeField] GameObject VITcounterObject;
    [SerializeField] GameObject AGIcounterObject;
    [SerializeField] GameObject INTcounterObject;

    public bool moderationSwitch { get; set; } //ポイントの増減をしてよいか返す
    public int skillPoint { get; set; }
    public int HPPoint { get; set; }
    public int STRPoint { get; set; }
    public int VITPoint { get; set; }
    public int AGIPoint { get; set; }
    public int INTPoint { get; set; }
    public int monsterNumber { get; set; }
    public int HPcounterPoint { get; set; }
    public int STRcounterPoint { get; set; }
    public int VITcounterPoint { get; set; }
    public int AGIcounterPoint { get; set; }
    public int INTcounterPoint { get; set; }
  

    private void Start()
    {
        moderationSwitch = false;

        if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
        {
            skillPoint = 100;

            GManager.instance.monsterDate[1] = 10;
            GManager.instance.monsterDate[2] = 1;
            GManager.instance.monsterDate[3] = 1;
            GManager.instance.monsterDate[4] = 1;
            GManager.instance.monsterDate[5] = 1;

            HPPoint = GManager.instance.monsterDate[1];
            STRPoint = GManager.instance.monsterDate[2];
            VITPoint = GManager.instance.monsterDate[3];
            AGIPoint = GManager.instance.monsterDate[4];
            INTPoint = GManager.instance.monsterDate[5];
        }

    }

    // Update is called once per frame
    void Update()
    {
        monsterNumber = GManager.instance.selectMonsterNumber;
        DisplayStatusPoint();
    }

    void DisplayStatusPoint()
    {
        skillText.text = ($"{skillPoint}");
        HPText.text = ($"{HPPoint}");
        STRText.text = ($"{STRPoint}");
        VITText.text = ($"{VITPoint}");
        AGIText.text = ($"{AGIPoint}");
        INTText.text = ($"{INTPoint}");

        if(GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
        {
            CounterDisplay();
        }



    }

    /// <summary>
    /// ポイントをマイナス1させる時の全体の処理
    /// </summary>
    /// <param name="experiencePoint"></param>　今のポイント数
    /// <param name="storagePoint"></param>  元々のポイント数
    public void MinusOperation(int experiencePoint, int storagePoint)
    {
        if (experiencePoint <= 0)
        {

        }
        else if (experiencePoint > storagePoint)
        {
            skillPoint++;
            moderationSwitch = true;
        }
    }

    /// <summary>
    /// ポイントをプラス1させる時の全体の処理
    /// </summary>
    /// <param name="experiencePoint"></param>　今のポイント数
    public void PlusOperation(int experiencePoint)
    {

        if (experiencePoint >= 500)
        {

        }
        else if (skillPoint > 0)
        {
            skillPoint--;
            moderationSwitch = true;

        }

    }

    /// <summary>
    /// ポイントをマイナス10させる時の全体の処理
    /// </summary>
    /// <param name="experiencePoint"></param>　今のポイント数
    /// <param name="storagePoint"></param>  元々のポイント数
    public void MinusTenOperation(int experiencePoint, int storagePoint)
    {
        if (experiencePoint <= 0)
        {

        }
        else if (experiencePoint - storagePoint >= 10)
        {
            skillPoint += 10;
            moderationSwitch = true;
        }
    }


    /// <summary>
    /// ポイントをプラス10させる時の全体の処理
    /// </summary>
    /// <param name="experiencePoint"></param>　今のポイント数
    public void PlusTenOperation(int experiencePoint)
    {

        if (experiencePoint >= 500)
        {

        }
        else if (skillPoint >= 10)
        {
            skillPoint -= 10;
            moderationSwitch = true;

        }

    }

    void CounterDisplay()
    {
        if(HPcounterPoint > 0)
        {
            HPcounterObject.SetActive(true);
            HPcounterText.text = ($"+{HPcounterPoint}");
        }
        else if(HPcounterPoint <= 0)
        {
            HPcounterObject.SetActive(false);
        }

        if (STRcounterPoint > 0)
        {
            STRcounterObject.SetActive(true);
            STRcounterText.text = ($"+{STRcounterPoint}");
        }
        else if (STRcounterPoint <= 0)
        {
            STRcounterObject.SetActive(false);
        }

        if (VITcounterPoint > 0)
        {
            VITcounterObject.SetActive(true);
            VITcounterText.text = ($"+{VITcounterPoint}");
        }
        else if (VITcounterPoint <= 0)
        {
            VITcounterObject.SetActive(false);
        }

        if (AGIcounterPoint > 0)
        {
            AGIcounterObject.SetActive(true);
            AGIcounterText.text = ($"+{AGIcounterPoint}");
        }
        else if (AGIcounterPoint <= 0)
        {
            AGIcounterObject.SetActive(false);
        }

        if (INTcounterPoint > 0)
        {
            INTcounterObject.SetActive(true);
            INTcounterText.text = ($"+{INTcounterPoint}");
        }
        else if (INTcounterPoint <= 0)
        {
            INTcounterObject.SetActive(false);
        }

       
    }
}
