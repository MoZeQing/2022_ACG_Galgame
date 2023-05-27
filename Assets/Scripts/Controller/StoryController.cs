using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    /// <summary>
    /// 这个是开始故事方法，调用剧情播放器
    /// </summary>
   void StoryBegin(StoryData story)//调用的UI?
    {
        DialogManager.LoadData();
    }
    /// <summary>
    /// 这个是结束故事更新角色属性和好感度
    /// </summary>
    void StoryEnd()
    {

        RoleManager.RoleDataUpData();//属性数据？
        StoryManager .AddHistory();
    }
}
