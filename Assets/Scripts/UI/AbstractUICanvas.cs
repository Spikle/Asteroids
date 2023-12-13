using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
    public abstract class AbstractUICanvas : MonoBehaviour
    {
        [SerializeField] protected Transform root;
        [SerializeField] protected List<AbstractMenuUI> menus = new List<AbstractMenuUI>();
        protected List<AbstractMenuUI> activeMenus = new List<AbstractMenuUI>();

        public T Open<T>() where T : AbstractMenuUI
        {
            AbstractMenuUI prefab = menus.FirstOrDefault(x => x is T);
            if (prefab == null)
            {
                Debug.LogError(typeof(T) + " is not found on UIManager");
                return null;
            }
            AbstractMenuUI menu = Instantiate(prefab, root);
            activeMenus.Add(menu);
            menu.Open();
            return menu as T;
        }

        public void Close<T>() where T : AbstractMenuUI
        {
            AbstractMenuUI menu = activeMenus.FirstOrDefault(x => x is T);
            if (menu == null)
                return;

            menu.Close();
            activeMenus.Remove(menu);
            Destroy(menu.gameObject);
        }

        public virtual void CloseAll()
        {
            foreach(var menu in activeMenus)
            {
                menu.Close();
                Destroy(menu.gameObject);
            }

            activeMenus.Clear();
        }

        public T GetActiveMenu<T>() where T : AbstractMenuUI
        {
            return activeMenus.FirstOrDefault(x => x is T) as T;
        }

        public bool IsActiveMenu<T>() where T : AbstractMenuUI
        {
            return GetActiveMenu<T>() != null;
        }

        public void UpdateView<T>() where T : AbstractMenuUI
        {
            var menu = activeMenus.FirstOrDefault(x => x is T) as T;
            menu.UpdateView();
        }
    }
}
