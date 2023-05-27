using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CheckForm : UIForm
{

    public Transform Transform;//战斗判定面板的坐标
    [Space]
    public Text Point;//在判定面板上显示点数
    public int PointCount = 0;//判定点数，默认为0

    //这里是判定显示弹窗，通常会在roll点后显示
    public void BattleCheck()//战斗时弹出窗口
    {
        Sequence quence = DOTween.Sequence();
        quence.Append(Transform.transform.DOMove(new Vector3(700, 280, 0), 0.5f));
        quence.AppendInterval(2);//暂停显示2s后滑出
        quence.Append(Transform.transform.DOMove(new Vector3(1050, 280, 0), 0.5f));
    }

    private void ShowRoll()
    {
        //这个方法被RoleManager调用，用于在面板上呈现判定点数
    }

    private void ClearRoll()
    {
        //这个方法被RoleManager调用，用于清楚面板上的判定点数
    }
}