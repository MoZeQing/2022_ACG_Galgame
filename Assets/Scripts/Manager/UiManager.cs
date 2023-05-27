using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : BaseManager
{
    //UI我不太了解，多多参考清哥的程序，红豆泥果咩纳塞
    /// <summary>
    /// 加载Ui(说实话我UI不太能看懂)
    /// </summary>
    void LoadData()
    {

    }
    /// <summary>
    /// 这个方法输入一个UI名来顶置UI
    /// </summary>
    void StickyForm(UIFormTag formTag)
    {

    }
    /// <summary>
    /// 这个方法隐藏UI
    /// </summary>
    void HideForm(UIFormTag formTag)
    {

    }
    /// <summary>
    /// 给其他类获取具体Form对象的方法
    /// </summary>
    /// <param name="formTag"></param>
    UIForm GetForm(UIFormTag formTag)
    {

    }
}
/// <summary>
/// 枚举，有几种UIForm就往里面写，这是让调用的人规范输入数据
/// </summary>
public enum UIFormTag
{

}
