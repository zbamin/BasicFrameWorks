using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : Singleton<UIManager>
{

    Stack<UI_System> ui_Stack = new Stack<UI_System>(); //후입선출로 관리

    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
        DontDestroyOnLoad(this);
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)  //씬이 바뀔때 마다 호출
    {
        ui_Stack = null;    //UI Stack 초기화
    }


    public void InsertStack(UI_System systemUI) //스택에 추가하기
    {
        ui_Stack.Push(systemUI);
    }


    public void DeleteStack()   //스택 지우기
    {
        if (ui_Stack.Count > 0)
        {
            ui_Stack.Peek().gameObject.SetActive(false);
            ui_Stack.Pop();
        }
        else
            return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeleteStack();
        }
    }

}