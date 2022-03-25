using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton : MonoBehaviour
{
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }
    protected static TargetManager _EM { get { return TargetManager.INSTANCE; } }
    protected static UI_Manager _UI { get { return UI_Manager.INSTANCE; } }
}
public class Singleton <T>: Singleton where T: Singleton
{
    public bool dontDestroy;
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake ()
    { 
        if (instance_ == null )
        {
            instance_ =this as T;
            if(dontDestroy) DontDestroyOnLoad (gameObject );
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


