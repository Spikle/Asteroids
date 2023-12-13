using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI
{
    public abstract class AbstractMenuUI : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void UpdateView();
    }
}
