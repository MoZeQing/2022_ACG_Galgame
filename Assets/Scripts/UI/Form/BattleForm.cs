using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//此类用于处理战斗GUI
//使用了DG Tween 插件
//因为UIManager没写完 所以先单独写在一个Scene里
public class BattleForm : UIForm
{
    //五个按钮 一个敌人和一个骰子动画
    
    public GameObject Attack;//攻击
    public GameObject Persuade;//说服
    public GameObject Flee;//逃跑
    public GameObject NextMove;//下一回合或结束战斗
    public GameObject Restart;//重新开始战斗 Debug
    [Space,SerializeField]
    private Image Enemy;//敌人
    private Image Dice;//骰子
    [Space]
    BattleManager BattleManager = new BattleManager();
    UiManager UiManager = new UiManager();
    CheckForm CheckForm = new CheckForm();
    public Transform gameCanvas;
    [Space]
    public Transform Transform;//判定面板的坐标
    [Space]
    public Text NextOrEnd;
    public string NextOrEndText = "继续";
    public Text Status;
    public string StatusText;
    public Text Name;
    public string NameText;//敌人名称
    [Space]
    private bool isBoss;//仅用于在StatusDialog上显示Boss战
    private bool isEnemy = false;
    private RoleData EnemyData;//敌人数据

    //-----------------------------按钮事件处理------------------------------------
    private void Attack_method()
    {
        Debugger();
        if(isEnemy == false)
        {
            BattleManager.Act("Player", "Attack");
        }
        else
        {
            BattleManager.Act(NameText);
        }
        RollAnim();
        if (true)//接口协调中
        {
            StatusDialog("成功！你击中了对方！");
        }
        else
        {
            StatusDialog("失败！对方未被击中！");
        }
    }

    private void Persuade_method()
    {
        Debugger();
        BattleManager.Act("Player", "Talk");
        RollAnim();
        if (true)//接口协调中
        {
            StatusDialog("成功！对方被说服了！");
            Close_Battle();
        }
        else
        {
            StatusDialog("失败！对方未被说服！");
        }
    }

    private void Flee_method()
    {
        Debugger();
        if(true)
        {
            StatusDialog("这是你发起的战斗，你不能逃跑！");
        }
        else
        {
            BattleManager.Act("Player", "Run");
            RollAnim();
            if (true)//接口协调中
            {
                StatusDialog("你逃跑了！");
                Close_Battle();
            }
            else
            {
                StatusDialog("逃跑失败！");
            }
        }

    }

    public void NextMove_method()//点击进行下一步（下一回合或结束战斗）
    {
        if (NextOrEndText == "结束战斗")//结束战斗
        {
            //UiManager.HideForm(UIFormTag.BattleForm);
        }
        else//继续
        {
            EnemyMove();
            NextMove.SetActive(false);//关闭下一回合按钮
            Dice.GetComponent<Image>().enabled = false;//关闭动画
        }


    }

    private void OpenRoundBtn()//激活继续按钮（功能）
    {
        NextOrEnd.text = NextOrEndText;
        NextMove.SetActive(true);
    }

    public void EnemyMove()//判断是否为敌方行动
    {

        if(isEnemy == false)
        {
            isEnemy = !isEnemy;
            Attack_method();
        }
        else
        {
            isEnemy = !isEnemy;
            MaskOp();
        }

    }

    public void StatusDialog(string Dialog)
    {
        StatusText = Dialog;
        Status.text = StatusText;
    }

    //-----------------------------UI管理与Debug---------------------------------------------------

    IEnumerator LoadEnemy()//加载并显示敌方名称数据
    {
        //获取敌方名字
        EnemyData.name = Name.text;
        NameText = Name.text;
        if (true)//怎么获取呢，这是个问题.......
            isBoss = true;
        else
            isBoss = false;
        //输出对方名字
        if (isBoss == true)
        {
            StatusDialog("这是一场Boss战!");
            StatusDialog("你的对手是"+ NameText + "!");
            yield return new WaitForSeconds(1.5f);//等1.5s
        }
        else
        {
            StatusDialog("你的对手是" + NameText + "!");
        }
        //判断谁发起的攻击
        if (true)
        {
            StatusText = NameText + "向你发起了攻击！";
            Status.text = StatusText;
        }
        else
        {
            StatusText = "你向"+ NameText + "发起了攻击！";
            Status.text = StatusText;
        }
    }

    private void Close_Battle()//完成战斗后处理GUI界面
    {
        NextOrEndText = "结束战斗";//切换按钮文字
        NextOrEnd.text = NextOrEndText;
        Attack.SetActive(!Attack.activeSelf);
        Persuade.SetActive(!Persuade.activeSelf);
        Flee.SetActive(!Flee.activeSelf);  
        Dice.GetComponent<Image>().enabled = false;
        Enemy.GetComponent<Image>().enabled = false;
    }

    private void Debugger()//Debug Test
    {
        Debug.Log("进行了一个回合！");
    }

    private void Restart_method()//重绘当前Scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void RollAnim()
    {
        Dice.GetComponent<Image>().enabled = true;//激活动画 这里先用Image代替
        MaskOp();
        Invoke("RollPanel", 2);//动画播放2s后执行
    }

    private void RollPanel()//判定面板滑入滑出
    {
        CheckForm.BattleCheck();
        Invoke("OpenRoundBtn", 2.5f);//判定面板滑出同时激活下一回合按钮
    }

    public void MaskOp()//禁用按钮
    {
        Attack.GetComponent<Button>().interactable = !Attack.GetComponent<Button>().interactable;
        Persuade.GetComponent<Button>().interactable = !Persuade.GetComponent<Button>().interactable;
        Flee.GetComponent<Button>().interactable = !Flee.GetComponent<Button>().interactable;
    }

    //----------------------------------------------------------------------------------------------

    void Start()
    {
        gameCanvas = GameObject.FindWithTag("Canvas").transform;
        GameObject go = (GameObject)Instantiate(Resources.Load("BattleCanvas"),gameCanvas);//实例化（
        StartCoroutine(LoadEnemy());
        Attack.GetComponent<Button>().onClick.AddListener(Attack_method);//为攻击按钮调用method
        Persuade.GetComponent<Button>().onClick.AddListener(Persuade_method);//同上
        Flee.GetComponent<Button>().onClick.AddListener(Flee_method);//同上
        NextMove.GetComponent<Button>().onClick.AddListener(NextMove_method);//同上
    }

}
