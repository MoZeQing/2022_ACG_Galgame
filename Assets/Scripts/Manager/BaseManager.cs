using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    //这里是Manager的父类
    public virtual void LoadData()
    {
        Debug.LogError("调用了baseManager的loadData方法，请确认是否正确继承");
    }

    public virtual void LoadData(int index)
    {
        Debug.LogError("调用了baseManager的loadData方法，请确认是否正确继承");
    }
}
