using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameObject FinishPanel;
        [SerializeField] private GameObject PausePanel;

        public void OpenFinishPanel()
        {
            FinishPanel.SetActive(true);
        }
        public void ControlPausePanel()
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
        }

    }
}
