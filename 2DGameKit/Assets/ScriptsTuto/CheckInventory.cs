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

    public UnityEvent m_onEnter;

    public DialogueCanvasController m_dialCtrl;

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
    }

    public void loadLevel(string sceneName)
    {
        m_transitionPoint.newSceneName = sceneName;
        m_transitionPoint.gameObject.SetActive(true);
    }

    public void DisplayMessage(KeyLvlMatch param) {
        m_dialCtrl.ActivateCanvasWithText(param.message);
        m_dialCtrl.DeactivateCanvasWithDelay(3);

    }

    IEnumerator LvlTransitionCorout(KeyLvlMatch param)
    {
        DisplayMessage(param);
        while (m_dialCtrl.isOpen) 
        {
            yield return null;
        }
        loadLevel(param.sceneName);
    }

    [System.Serializable]
    public class KeyLvlMatch {

        public string keyId;

        public string sceneName;

        public string message;

    }

}
