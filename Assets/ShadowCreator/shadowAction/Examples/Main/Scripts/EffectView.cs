using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectView : BaseView {

    GameObject mySelf;
    public GameObject icon;
    public GameObject backGround;
    public TextMesh title;
    public TextMesh info;
    public Material backGroundEnterMaterial;
    public Material backGroundExitMaterial;
    public Material backGroundClickMaterial;
    Color titleEnterColor;
    Color titleExitColor;
    Color titleClickColor;
    Color infoEnterColor;
    Color infoExitColor;
    Color infoClickColor;
    public float effectLevel = 0.01f;

    Vector3 mySelfLocalPosition;
    Vector3 mySelflocalEulerAngles;
    Vector3 mySelfLocalScal;
    BoxCollider mySelfBoxCollider;
    Vector3 mySelfBoxColliderInitLocalSize;
    Vector3 mySelfBoxColliderInitLocalPosition;

    Vector3 iconLocalPosition;
    Vector3 iconlocalEulerAngles;
    Vector3 iconLocalScal;

    Vector3 backGroundLocalPosition;
    Vector3 backGroundlocalEulerAngles;
    Vector3 backGroundLocalScal;
    MeshRenderer backGroundMeshRenderer;

    Vector3 titleLocalPosition;
    Vector3 titlelocalEulerAngles;
    Vector3 titleLocalScal;
    TextMesh titleTextMesh;

    Vector3 infoLocalPosition;
    Vector3 infolocalEulerAngles;
    Vector3 infoLocalScal;
    TextMesh infoTextMesh;

    public override void Start() {
        base.Start();
        mySelf = gameObject;

        titleEnterColor = Color.white;
        titleExitColor = Color.green;
        titleClickColor = Color.yellow;
        infoEnterColor = Color.white;
        infoExitColor = Color.green;
        infoClickColor = Color.yellow;

        if (mySelf) {
            mySelfLocalPosition = mySelf.transform.localPosition;
            mySelflocalEulerAngles = mySelf.transform.localEulerAngles;
            mySelfLocalScal = mySelf.transform.localScale;
            mySelfBoxCollider = mySelf.GetComponent<BoxCollider>();
            mySelfBoxColliderInitLocalSize = mySelfBoxCollider.size;
            mySelfBoxColliderInitLocalPosition = mySelfBoxCollider.transform.localPosition;
        }
        if (icon) {
            iconLocalPosition = icon.transform.localPosition;
            iconlocalEulerAngles = icon.transform.localEulerAngles;
            iconLocalScal = icon.transform.localScale;
        }
        if (backGround) {
            backGroundLocalPosition = backGround.transform.localPosition;
            backGroundlocalEulerAngles = backGround.transform.localEulerAngles;
            backGroundLocalScal = backGround.transform.localScale;
            backGroundMeshRenderer =  backGround.GetComponent<MeshRenderer>();
            if (!backGroundMeshRenderer) {
                backGroundMeshRenderer = backGround.AddComponent<MeshRenderer>();
            }
            backGroundMeshRenderer.material = backGroundExitMaterial;

        }
        if (title) {
            titleLocalPosition = title.transform.localPosition;
            titlelocalEulerAngles = title.transform.localEulerAngles;
            titleLocalScal = title.transform.localScale;
            titleTextMesh = title.gameObject.GetComponent<TextMesh>();
            if (!titleTextMesh) {
                titleTextMesh = title.gameObject.AddComponent<TextMesh>();
            }
            titleTextMesh.color = titleExitColor;
        }
        if (info) {
            infoLocalPosition = info.transform.localPosition;
            infolocalEulerAngles = info.transform.localEulerAngles;
            infoLocalScal = info.transform.localScale;
            infoTextMesh = info.gameObject.GetComponent<TextMesh>();
            if (!infoTextMesh) {
                infoTextMesh = info.gameObject.AddComponent<TextMesh>();
            }
            infoTextMesh.color = infoExitColor;
        }
    }
    


    public override void OnEnter(BaseEventData data) {
        base.OnEnter(data);

        if (icon) {
            icon.transform.DOKill();
            icon.transform.DOLocalMoveZ(iconLocalPosition.z - effectLevel * 1.5f, 0.4f);
        }
        if (backGround) {
            //backGround.transform.DOKill();
            //backGround.transform.DOLocalMoveZ(backGroundLocalPosition.z - effectLevel * 1.1f, 0.3f);
            backGroundMeshRenderer.material = backGroundEnterMaterial;
        }
        if (title) {
            title.transform.DOKill();
            title.transform.DOLocalMoveZ(titleLocalPosition.z - effectLevel * 1.2f, 0.3f);
            titleTextMesh.color = titleEnterColor;
        }
        if (info) {
            info.transform.DOKill();
            info.transform.DOLocalMoveZ(infoLocalPosition.z - effectLevel * 1.2f, 0.3f);
            infoTextMesh.color = infoEnterColor;
        }
        if (mySelf) {
            mySelf.transform.DOKill();
            mySelf.transform.DOScale(mySelfLocalScal * 1.1f, 0.5f);
            mySelf.transform.DOLocalMoveZ(mySelfLocalPosition.z - effectLevel * 1.2f, 0.3f);
            //mySelfBoxCollider.size = mySelfBoxColliderInitLocalSize*1.5f;

        }
    }
    public override void OnExit(BaseEventData data) {
        base.OnExit(data);
        if (mySelf) {
            mySelf.transform.DOKill();
            mySelf.transform.DOScale(mySelfLocalScal, 0.5f);
            mySelfBoxCollider.size = mySelfBoxColliderInitLocalSize;
        }
        if (icon) {
            icon.transform.DOKill();
            icon.transform.DOLocalMoveZ(iconLocalPosition.z, 0.4f);
        }
        if (backGround) {
            backGround.transform.DOKill();
            backGround.transform.DOLocalMoveZ(backGroundLocalPosition.z, 0.3f);
            backGroundMeshRenderer.material = backGroundExitMaterial;
        }
        if (title) {
            title.transform.DOKill();
            title.transform.DOLocalMoveZ(titleLocalPosition.z, 0.3f);
            titleTextMesh.color = titleExitColor;
        }
        if (info) {
            info.transform.DOKill();
            info.transform.DOLocalMoveZ(infoLocalPosition.z, 0.3f);
            infoTextMesh.color = infoExitColor;
        }

    }
    public override void OnDown(BaseEventData data) {
        base.OnDown(data);
    }
    public override void OnClick(BaseEventData data) {
        base.OnClick(data);
        if (backGround) {
            backGroundMeshRenderer.material = backGroundClickMaterial;
        }
        if (title) {
            titleTextMesh.color = titleClickColor;
        }
        if (info) {
            infoTextMesh.color = infoClickColor;
        }
    }

    public override void OnUp(BaseEventData data) {
        base.OnUp(data);
    }

}
