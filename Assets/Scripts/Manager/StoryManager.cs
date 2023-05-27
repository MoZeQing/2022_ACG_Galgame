using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StoryManager : BaseManager
{
    public string[] hs;
    public List<string> h;
    private Dictionary<string, StoryData> _stories = new Dictionary<string, StoryData>();
    private Dictionary<string,string> _nowStory=new Dictionary<string, string>();
    private TimeData _time;
    private string _storyName;
    private string s;
    private string p;
    
    /// <summary>
    /// 加载数据库中的故事
    /// </summary>
    public override void LoadData()//直接拿了。。。
    {
        _stories.Clear();
        //StoryScriptableObject[] data = Resources.LoadAll<StoryScriptableObject>("Data/StoryData");
        //foreach (StoryScriptableObject story in data)
        //{
        //    _stories.Add(story.storyData.tag, story.storyData);
        //}
    }
    /// <summary>
    /// 这个是加载存档中的历史事件
    /// </summary>
    public void LoadHistory()
    {
        //hs=SavedData .historyStorys;
        //h=hs.ToList();

    }
    /// <summary>
    /// 将经历过的事件加入历史事件
    /// </summary>
    public void AddHistory()
    {
        //if(! _storyName =="")//基础事件
        //{    
        //    h.Add(_storyName );
        //}
    }
    /// <summary>
    /// 给外部插件获取历史事件
    /// </summary>
    public string[] GetHistory()
    {
        //hs=h.ToArray;
        //return hs;
        return null;
    }
    /// <summary>
    /// 调用故事操作类开始故事
    /// </summary>
    public void StartStory(string storyName)
    {    
        //_storyName =storyName ;
        //StoryController .StoryBegin(_stories [storyName ]);
        //StoryController .StoryEnd();
    }
    /// <summary>
    /// 为UI返回当前时间可执行故事（地点，事件名）(时间去找TimeManager要)
    /// </summary>
    public Dictionary<string ,string> NowStory()//需要时间表数据
    {
        //_time=TimeManager.GetTime();
        //_nowStory .Clear ();
        //for(;; )//条件待定
        //{


        //    if(!(h.Contains (s)||s==null))
        //    {
        //        _nowStory [p]=s;
        //    }
        //}
        //return _nowStory ;
        return null;
    }

}
/// <summary>
/// 这个类是故事类，通常包含一个故事的文本（这里包含什么要看剧情播放器）
/// </summary>
public class StoryData
{
    public string storyName;
    public string[] storyData;
    public string[] roleName;
    public Property property;
    
}
