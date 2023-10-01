using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoryAttributes
{
    [SerializeField]
    public PersonalAttributes type;
    [SerializeField]
    public int value;
}

[Serializable]
public class StoryObject
{
    [Header("对象名称多语言")]
    [SerializeField]
    public int name;
    [Header("对象ID")]
    [SerializeField]
    public int id;
}

[Serializable]
public class StoryAction : StoryObject
{
    [Header("行为执行成功的属性")]
    [SerializeField]
    public StoryAttributes[] thresholdAttributes;
    [Header("行为添加的属性")]
    [SerializeField]
    public StoryAttributes[] attributes;
}

[Serializable]
public class StoryScene : StoryObject
{
    [Header("场景进入的属性门槛")]
    [SerializeField]
    public StoryAttributes[] thresholdAttributes;
    [Header("场景中出现的行为")]
    [SerializeField]
    public StoryAction[] actions;
}

public class Storyline : ScriptableObject
{
    [Header("故事线长度")]
    [SerializeField]
    public int length;
    [Header("故事出现场景配置")]
    [SerializeField]
    public StoryScene[] scenes;
}
