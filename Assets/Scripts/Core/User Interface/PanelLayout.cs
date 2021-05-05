using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class PanelLayout : MonoBehaviour
    {
        protected readonly List<Panel> panels = new List<Panel>();

        protected Panel currentPanel;

        protected abstract void Initialise();

        public void Change<T>() where T : Panel
        {
            for (int i = 0; i < panels.Count; i++)
            {
                var panel = panels[i];

                if (panel is T)
                {
                    if (currentPanel != null)
                    {
                        currentPanel.Hide();
                    }

                    currentPanel = panel;
                    currentPanel.Show();
                }
            }
        }

        public T GetPanel<T>() where T : Panel
        {
            for (int i = 0; i < panels.Count; i++)
            {
                if (panels[i] is T panel)
                {
                    return panel;
                }
            }

            return null;
        }

        public virtual void Hide()
        {
            if (currentPanel != null)
            {
                currentPanel.Hide();
            }
        }

        public virtual void Show()
        {
            if (currentPanel != null)
            {
                currentPanel.Show();
            }
        }
    }
}
