using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Gamekit2D;

public class CheckInventory : MonoBehaviour
{

    public InventoryController m_inventoryController;

    public KeyLvlMatch[] m_items;

    public TransitionPoint m_transitionPoint;

    public DialogueCanvasController m_dialCtrl;

    public string m_gotKeysMessage;

    public Animator m_doorAnimator;

    public void Start()
    {
        m_transitionPoint.gameObject.SetActive(false);
    }

    public void checkInventory()
    {
        foreach(KeyLvlMatch key in m_items)
        {
            if (!m_inventoryController.HasItem(key.keyId))
            {
                Debug.Log("no key with id : " + key.keyId);
                StartCoroutine(LvlTransitionCorout(key));
                return;
            }
        }
        DisplayMessage(m_gotKeysMessage);
        m_doorAnimator.Play("DoorOpening");
    }

    public void LoadLevel(string sceneName)
    {
        m_transitionPoint.newSceneName = sceneName;
        m_transitionPoint.gameObject.SetActive(true);
    }

    public void DisplayMessage(string message) {
        m_dialCtrl.ActivateCanvasWithText(message);
        m_dialCtrl.DeactivateCanvasWithDelay(3);

    }

    IEnumerator LvlTransitionCorout(KeyLvlMatch param)
    {
        DisplayMessage(param.message);
        while (m_dialCtrl.isOpen) 
        {
            yield return null;
        }
        LoadLevel(param.sceneName);
    }

    [System.Serializable]
    public class KeyLvlMatch {

        public string keyId;

        public string sceneName;

        public string message;

    }

}
