using ShadowKit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseList : BaseWindow {

    public GameObject nextButton;
    public GameObject preButton;
    public MeshRenderer nextButtonMeshRenderer;
    public MeshRenderer preButtonMeshRenderer;
    public Material buttonActiveMaterial;
    public Material buttonInActiveMaterial;
    public Material buttoClickMaterial;
    public TextMesh info;
    public int sumPage;
    public int currentPage;
    public List<BaseView> baseViews;
    public List<object> configs;
    bool isInitFinish;
    
    void UpdateButtonsStatus() {
        if (sumPage <= 1) {
            NextAndPerButtonInActive();
        } else {
            if (currentPage == sumPage) {
                if (sumPage == 2) {
                    PerButtonActive();
                } else {
                    NextAndPerButtonActive();
                }
            } else if (currentPage == 1) {
                NextButtonActive();
            }
        }
    }
    void NextButtonActive() {
        nextButton.SetActive(true);
        preButton.SetActive(true);
        nextButtonMeshRenderer.material = buttonActiveMaterial;
        preButtonMeshRenderer.material = buttonInActiveMaterial;
    }
    void PerButtonActive() {
        nextButton.SetActive(true);
        preButton.SetActive(true);
        nextButtonMeshRenderer.material = buttonInActiveMaterial;
        preButtonMeshRenderer.material = buttonActiveMaterial;
    }
    void NextAndPerButtonActive() {
        nextButton.SetActive(true);
        preButton.SetActive(true);
        nextButtonMeshRenderer.material = buttonActiveMaterial;
        preButtonMeshRenderer.material = buttonActiveMaterial;
    }
    void NextAndPerButtonInActive() {
        nextButton.SetActive(true);
        preButton.SetActive(true);
        nextButtonMeshRenderer.material = buttonInActiveMaterial;
        preButtonMeshRenderer.material = buttonInActiveMaterial;
    }

    public override void Start() {
        base.Start();
        Init();
        Refresh();
    }

    public override void Init() {
        if (false == isInitFinish) {
            isInitFinish = true;
            if (configs == null) {
                configs = new List<object>();
            }
            currentPage = 1;
            sumPage = 1;
            AddButtonEvent();
        }
    }

    public virtual void Refresh() {
        Init();
        int aPageMaxView = baseViews.Count;
        int sumConfigCount = configs.Count;
        sumPage = sumConfigCount / aPageMaxView + (((sumConfigCount % aPageMaxView) != 0) ? 1 : 0);
        if (sumPage == 0)
            sumPage = 1;
        UpdateButtonsStatus();
        info.text = currentPage + "/"+ sumPage;
        foreach (BaseView _baseView in baseViews) {
            _baseView.gameObject.SetActive(false);
            _baseView.config = null;
        }
        for (int i = (currentPage-1)* aPageMaxView , j = 0; j < ((currentPage==sumPage) ? (sumConfigCount - aPageMaxView*(currentPage-1)) : aPageMaxView) ; i++,j++) {
            baseViews[j].gameObject.SetActive(true);
            baseViews[j].config = configs[i];
            baseViews[j].Init();
            baseViews[j].Refresh();
            
        }
    }



    public void AddButtonEvent() {
        if (nextButton && !nextButton.GetComponent<SCButton>()) {
            nextButton.AddComponent<SCButton>();
            EventManager.AddTriggerListener(nextButton, EventTriggerType.PointerEnter, OnNextButtonEnter);
            EventManager.AddTriggerListener(nextButton, EventTriggerType.PointerDown, OnNextButtonDown);
            EventManager.AddTriggerListener(nextButton, EventTriggerType.PointerUp, OnNextButtonUp);
            EventManager.AddTriggerListener(nextButton, EventTriggerType.PointerExit, OnNextButtonExit);
            EventManager.AddTriggerListener(nextButton, EventTriggerType.PointerClick, OnNextButtonClick);
        }
        if (preButton && !preButton.GetComponent<SCButton>()) {
            preButton.AddComponent<SCButton>();
            EventManager.AddTriggerListener(preButton, EventTriggerType.PointerEnter, OnPreButtonEnter);
            EventManager.AddTriggerListener(preButton, EventTriggerType.PointerDown, OnPreButtonDown);
            EventManager.AddTriggerListener(preButton, EventTriggerType.PointerUp, OnPreButtonUp);
            EventManager.AddTriggerListener(preButton, EventTriggerType.PointerExit, OnPreButtonExit);
            EventManager.AddTriggerListener(preButton, EventTriggerType.PointerClick, OnPreButtonClick);
        }
    }
    public virtual void OnNextButtonEnter(BaseEventData data) {

    }
    public virtual void OnNextButtonDown(BaseEventData data) {
        if (currentPage < sumPage) {
            nextButtonMeshRenderer.material = buttoClickMaterial;
        }
    }
    public virtual void OnNextButtonUp(BaseEventData data) {
        currentPage = (currentPage + 1) > sumPage ? sumPage : (currentPage + 1);
        Refresh();
    }
    public virtual void OnNextButtonExit(BaseEventData data) {

    }
    public virtual void OnNextButtonClick(BaseEventData data) {

        
    }
    public virtual void OnPreButtonEnter(BaseEventData data) {
        
    }
    public virtual void OnPreButtonDown(BaseEventData data) {
        if (currentPage > 1) {
            preButtonMeshRenderer.material = buttoClickMaterial;
        }
    }
    public virtual void OnPreButtonUp(BaseEventData data) {
        currentPage = (currentPage - 1) < 1 ? 1 : (currentPage - 1);
        Refresh();
    }
    public virtual void OnPreButtonExit(BaseEventData data) {

    }
    public virtual void OnPreButtonClick(BaseEventData data) {
        
        
    }
}
