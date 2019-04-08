using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI {
    public abstract class BaseUIPanel :MonoBehaviour, IBaseUIPanelTimeLife {

        public Transform content;
        private BoxCollider[] boxColliders;

        [NonSerialized]
        public CanvasGroup canvasGroup;

        void  Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null) {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            boxColliders = GetComponentsInChildren<BoxCollider>(true);
        }

        void CloseBoxColliser() {
            foreach (BoxCollider bc in boxColliders) {
                bc.enabled = false;
            }
        }
        void OpenBoxColliser() {
            foreach (BoxCollider bc in boxColliders) {
                bc.enabled = true;
            }
        }

        /// <summary>
        /// UIPanel 显示方法
        /// </summary>
        public virtual void OnEnter(object parameter = null) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            OpenBoxColliser();
        }

        /// <summary>
        /// UIPanel暂停方法
        /// </summary>
        public virtual void OnPause(object parameter = null) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            CloseBoxColliser();
        }

        /// <summary>
        /// UIPanel恢复方法
        /// </summary>
        public virtual void OnResume(object parameter = null) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            OpenBoxColliser();
        }

        /// <summary>
        /// UIPanel退出方法
        /// </summary>
        public virtual void OnExit(object parameter = null) {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            CloseBoxColliser();
        }
    }
}
